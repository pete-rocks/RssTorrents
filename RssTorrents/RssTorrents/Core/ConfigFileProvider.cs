using System;

namespace RssTorrents
{
	public class ConfigFileProvider : IConfigFileProvider
	{
		public string GetConfigFileLocation()
		{
			return "RssTorrents.configuration";
		}
	}
}

