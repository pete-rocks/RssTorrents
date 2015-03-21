using System;
using NLog;
using System.Collections.Generic;
using System.IO;

namespace RssTorrents
{
	public class ConfigReader : IConfigReader
	{
		private readonly string _configFileLocation;

		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		public ConfigReader (string configFileLocation)
		{
			_configFileLocation = configFileLocation;
		}


		public List<RssFeed> ReadFeeds()
		{
			//check if file exists
			//var config = File.ReadAllText("RssTorrents.configuration");

			//JsonSerializer j = new Newtonsoft.Json.JsonSerializer ();
			//RssTorrentsConfiguration config = 


			return null;
		}




	}
}

