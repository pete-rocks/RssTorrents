using System;
using System.Collections.Generic;
using System.Net;

namespace RssTorrents
{
	public class RssFeed
	{
		public string FeedName { get ; private set;}
		public string FeedURL { get; private set; }

		public DateTime LastChecked { get ;set;}
		public DateTime LastDownloaded { get ;set;}

		public List<Show> Shows { get; private set;}

		private RssFetcher Fetcher { get; set; } 


		public RssFeed (string feedName, string feedURL)
		{
			FeedName = feedName;
			FeedURL = feedURL;

			Fetcher = new RssFetcher ();
		}

		public void Update()
		{
			Shows = Fetcher.GetAllShows (FeedURL);
			LastChecked = DateTime.Now;
		}

		public void DownloadNewShows()
		{
			foreach(var show in Shows)
			{
				var fileName = @"/Users/Pete/Downloads/" + show.EpisodeName + ".torrent";
				using (WebClient Client = new WebClient ())
				{
					Client.DownloadFile(show.TorrentUrl, fileName);
				}
			}

			LastDownloaded = DateTime.Now;
		}




	}
}

