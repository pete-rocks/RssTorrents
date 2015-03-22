using System;

namespace RssTorrents
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//set up autofac
			AutoFacInstaller.Install();

			var reader = AutoFacInstaller.Get<IConfigReader>();

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
