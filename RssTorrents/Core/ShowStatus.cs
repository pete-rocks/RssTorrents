using System;
using System.Collections.Generic;
using NLog;

namespace RssTorrents
{
	public class ShowStatus
	{
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public RssFeed RssFeed { get ; set;}
		public DateTime LastChecked {get ;set;}
		public DateTime LastDownloaded {get ;set;}

		public List<Show> Shows { get; private set;}


		public ShowStatus (RssFeed rssFeed)
		{
			RssFeed = rssFeed;
			Shows = new List<Show> ();
			LastChecked = DateTime.MinValue;
			LastDownloaded = DateTime.MinValue;
		}


		public void CheckRssFeed()
		{
			RssFetcher fetcher = new RssFetcher ();
			var ok = fetcher.RssFeedExists (this.RssFeed.FeedURL);

			if (ok) {

				fetcher.GetAllShows (this.RssFeed.FeedURL);
			}
			else{
				logger.Info ("Unable to access feed");

			}

		}







	}
}

