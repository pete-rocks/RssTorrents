using System;
using System.Collections.Generic;
using System.Net;
using NLog;

namespace RssTorrents
{
	public class RssFeed
	{
		public string FeedName { get ; private set;}
		public string FeedURL { get; private set; }
		public List<Show> Shows { get; private set;}
		public DateTime LastChecked { get ;set;}
		public DateTime LastDownloaded { get ;set;}
		private RssFetcher Fetcher { get; set; } 
	
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public RssFeed (string feedName, string feedURL)
		{
			FeedName = feedName;
			FeedURL = feedURL;

			Fetcher = new RssFetcher ();
		}

		public void Update()
		{
			Shows = Fetcher.GetAllShows(FeedURL);
			LastChecked = DateTime.Now;
		}

		public void DownloadNewShows()
		{
			try
			{
				foreach(var show in Shows)
				{
					//var fileName = @"/Users/Pete/Downloads/" + show.EpisodeName + ".torrent";
					var fileName = @"/Users/Pete/temp/" + show.EpisodeName + ".torrent";
					logger.Info ("Trying to save {0} to {1}", show.TorrentUrl, fileName);
					using (WebClient Client = new WebClient ())
						Client.DownloadFile(show.TorrentUrl, fileName);
				}

				LastDownloaded = DateTime.Now;
			}
			catch(Exception ex) 
			{
				logger.Error ("Error while trying to save .torrent file", ex);
			}
		}

	}
}

