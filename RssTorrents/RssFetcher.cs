using System;
using System.Net;
using System.IO;

namespace RssTorrents
{
	public class RssFetcher
	{
		public RssFetcher ()
		{
		}

		public bool RssFeedExists(string feedUrl)
		{
			WebRequest request = WebRequest.Create(feedUrl);

			var response = request.GetResponse ();

			Stream dataStream = response.GetResponseStream ();


			response.Close();

		}

	}
}

