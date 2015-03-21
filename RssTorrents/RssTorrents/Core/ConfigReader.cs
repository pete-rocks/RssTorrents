using System;
using NLog;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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

		public RssTorrentsConfiguration ReadConfiguration()
		{
			try
			{
				if (!File.Exists (_configFileLocation) && !CreateConfigurationFile()) 
					return null;

				logger.Info("Reading config file {0}", _configFileLocation);
				var configJson = File.ReadAllText(_configFileLocation);
				return JsonConvert.DeserializeObject<RssTorrentsConfiguration>(configJson);
			}
			catch(Exception ex)
			{
				logger.Error("Unable to read configuration file", ex);
				return null;
			}
		}

		public void SaveConfiguration(RssTorrentsConfiguration config)
		{
			logger.Info("Saving config file {0}", _configFileLocation);
			string json = JsonConvert.SerializeObject (config, Formatting.Indented);
			File.WriteAllText (_configFileLocation, json);
		}

		private bool CreateConfigurationFile ()
		{
			try
			{
				logger.Info ("Creating config file {0}", _configFileLocation);
				var tempConfig = new RssTorrentsConfiguration ();
				string json = JsonConvert.SerializeObject (tempConfig, Formatting.Indented);
				File.WriteAllText (_configFileLocation, json);
			}
			catch(Exception ex)
			{
				logger.Error("Unable to create configuration file", ex);
				return false;
			}
			return true;

		}
	}
}

