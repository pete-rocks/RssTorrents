using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using NLog;
using System.Threading.Tasks;

namespace RssTorrents
{
	public class RssFeed : IRssFeed
	{
		public string FeedName { get ; set; }
		public string FeedURL { get; set; }
		public List<Show> Shows { get; set; }
		public DateTime LastChecked { get; set;}
		public DateTime LastDownloaded { get; set;}

		private IRssFetcher Fetcher { get; set; } 
	
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public RssFeed (string feedName, string feedURL)
		{
			FeedName = feedName;
			FeedURL = feedURL;

			Fetcher = AutoFacInstaller.Get<IRssFetcher>();
		}

		public void Update()
		{
			Shows = Fetcher.GetAllShows(FeedURL);
			LastChecked = DateTime.Now;
		}

		public async Task DownloadNewShows()
		{
			try
			{
				
				//Task.WhenAll(Shows.Select(show => DownloadShow(show)));

				var tasks = Shows.Select(show => DownloadShow(show));

				await Task.WhenAll(tasks);

				tasks.First().Wait();


				LastDownloaded = DateTime.Now;
			}
			catch(Exception ex) 
			{
				logger.Error ("Error while trying to save .torrent files", ex);
			}
		}

		private async Task DownloadShow(Show show)
		{
			try
			{
				var fileName = @"/Users/Pete/temp/" + show.EpisodeName + ".torrent";
				logger.Info ("Trying to save {0} to {1}", show.TorrentUrl, fileName);

				using (var webClient = new WebClient())
					await webClient.DownloadFileTaskAsync(new Uri(show.TorrentUrl), fileName);

				return;
			}
			catch (Exception ex)
			{
				logger.Error ("Error while trying to save .torrent file", ex);
			}
		}

	}
}

