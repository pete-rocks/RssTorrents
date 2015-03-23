using System;
using System.Collections.Generic;

namespace RssTorrents
{
	public interface IConfigReader : IService
	{
		RssTorrentsConfiguration ReadConfiguration();
		void SaveConfiguration(RssTorrentsConfiguration config);
	}
}

