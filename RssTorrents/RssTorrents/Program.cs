using System;

namespace RssTorrents
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			ConfigReader reader = new ConfigReader("RssTorrents.configuration");
			var config = reader.ReadConfiguration();

			Console.WriteLine ("Starting downloads...");

			foreach(var feed in config.Feeds)
			{
				feed.Update();
				feed.DownloadNewShows();
			}

			Console.WriteLine ("Downloaded!");

			reader.SaveConfiguration(config);

		}
	}
}
