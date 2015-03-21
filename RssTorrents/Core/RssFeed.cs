using System;

namespace RssTorrents
{
	public class RssFeed
	{
		public string FeedURL { get; private set; }

		public RssFeed (string feedURL)
		{
			FeedURL = feedURL;
		}



	}
}

