using System;
using System.Net;
using System.IO;
using NLog;
using System.Collections.Generic;
using RestSharp;

namespace RssTorrents
{
	public class RssFetcher
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public RssFetcher ()
		{
		}

		public bool RssFeedExists(string feedUrl)
		{
			try
			{
				logger.Info ("Connecting...");
				var request = (HttpWebRequest)WebRequest.Create (feedUrl);
				request.Timeout = 60000; //give it 1 minute
				request.KeepAlive = true;
				request.GetResponse();
				return true;

			}
			catch (WebException e)
			{
				logger.Error ("Can't connect to {0}", feedUrl);
				logger.Error (e);
				return false;
			}
			catch (Exception e)
			{
				logger.Error ("Can't connect to {0}", feedUrl);
				logger.Error (e);
				return false;
			}

		}

		public IRestResponse GetRssResponse(string feedUrl)
		{
			var client = new RestClient(feedUrl);
			var request = new RestRequest("", Method.GET);
			var response = client.Get (request);

			return response;
		}

		public List<Show> GetAllShows(string feedUrl)
		{
			var response = GetRssResponse (feedUrl);





			return null;

		}

	
	}
}

