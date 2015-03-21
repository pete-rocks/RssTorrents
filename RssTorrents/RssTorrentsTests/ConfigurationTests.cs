using NUnit.Framework;
using System;
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
			var fileLocation = Guid.NewGuid().ToString();

			IConfigReader reader = new ConfigReader(fileLocation);
			var config = reader.ReadConfiguration();

			Assert.IsNotNull(config);
			Assert.IsNotNull(config.Feeds);
			Assert.AreEqual(0, config.Feeds.Count);
			Assert.IsTrue(File.Exists(fileLocation));

			//tidy up file
			File.Delete(fileLocation);
		}

		[Test()]
		public void FilesAreSavedAndRead()
		{
			var fileLocation = Guid.NewGuid().ToString();
			IConfigReader reader = new ConfigReader(fileLocation);

			var config = new RssTorrentsConfiguration();
			config.Feeds.Add(new RssFeed("test","testURL"));

			reader.SaveConfiguration(config);

			var newConfig = reader.ReadConfiguration();

			Assert.AreEqual(config.Feeds.Count, newConfig.Feeds.Count);
			Assert.AreEqual(config.Feeds[0].FeedName, newConfig.Feeds[0].FeedName);
			Assert.AreEqual(config.Feeds[0].FeedURL, newConfig.Feeds[0].FeedURL);

			//tidy up file
			File.Delete(fileLocation);
		}
			
	}
}

