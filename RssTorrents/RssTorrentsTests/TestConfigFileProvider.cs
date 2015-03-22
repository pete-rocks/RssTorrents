using System;
using RssTorrents;

namespace RssTorrentsTests
{
	public class TestConfigFileProvider : IConfigFileProvider
	{
		private string _fileLocation;
		
		public TestConfigFileProvider ()
		{
			_fileLocation = Guid.NewGuid().ToString();
		}

		public string GetConfigFileLocation ()
		{
			return _fileLocation;
		}
	}
}

