using System;

namespace RssTorrents
{
	public interface IConfigFileProvider : IService
	{
		string GetConfigFileLocation();
	}
}

