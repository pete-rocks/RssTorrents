using NUnit.Framework;
using System.IO;
using RssTorrents;

namespace RssTorrentsTests
{
	[TestFixture ()]
	public class ConfigurationTests
	{
		[Test ()]
		public void ConfigurationFileIsCreatedWhenNoneExists ()
		{
			var fileProvider = new TestConfigFileProvider();

			IConfigReader reader = new ConfigReader(fileProvider);
			var config = reader.ReadConfiguration();

			Assert.IsNotNull(config);
			Assert.IsNotNull(config.Feeds);
			Assert.AreEqual(0, config.Feeds.Count);
			Assert.IsTrue(File.Exists(fileProvider.GetConfigFileLocation()));

			//tidy up file
			File.Delete(fileProvider.GetConfigFileLocation());
		}

		[Test()]
		public void FilesAreSavedAndRead()
		{
			var fileProvider = new TestConfigFileProvider();
			IConfigReader reader = new ConfigReader(fileProvider);

			var config = new RssTorrentsConfiguration();
			config.Feeds.Add(new RssFeed("test","testURL"));

			reader.SaveConfiguration(config);

			var newConfig = reader.ReadConfiguration();

			Assert.AreEqual(config.Feeds.Count, newConfig.Feeds.Count);
			Assert.AreEqual(config.Feeds[0].FeedName, newConfig.Feeds[0].FeedName);
			Assert.AreEqual(config.Feeds[0].FeedURL, newConfig.Feeds[0].FeedURL);

			//tidy up file
			File.Delete(fileProvider.GetConfigFileLocation());
		}
			
	}
}

