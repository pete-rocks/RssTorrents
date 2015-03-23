using System;
using System.Linq;
using System.Threading.Tasks;

namespace RssTorrents
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			AutoFacInstaller.Install();

			var reader = AutoFacInstaller.Get<IConfigReader>();

			var config = reader.ReadConfiguration();

			config.Feeds = new System.Collections.Generic.List<RssFeed>();
			config.Feeds.Add(new RssFeed("Petes stuff","http://showrss.info/rss.php?user_id=240668&hd=0&proper=0&magnets=false"));

			Console.WriteLine ("Starting downloads...");

			Task.WhenAll(config.Feeds.Select(f => f.DownloadNewShows())).Wait();

			Console.WriteLine ("Downloaded!");

			reader.SaveConfiguration(config);
		}
	}
}
