using System;
using NLog;
using System.Collections.Generic;
using QDFeedParser;

namespace RssTorrents
{
	public class RssFetcher
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public List<Show> GetAllShows(string feedUrl)
		{
			var result = new List<Show> ();

			Uri feeduri = new Uri(feedUrl);
			IFeedFactory factory = new HttpFeedFactory ();

			if (factory.PingFeed (feeduri)) 
			{
				IFeed feed = factory.CreateFeed (feeduri);
				logger.Info (feed.Title + " -> " + feed.Items.Count);

				foreach (var item in feed.Items) 
				{
					logger.Info (item.Content);
					result.Add(new Show(item.Link, item.Title));
				}
			}
			else 
			{
				logger.Error ("Invalid feed URL " + feedUrl);
			}

			logger.Info (result.Count + " shows found");

			return result;
		}
				
	}
}

