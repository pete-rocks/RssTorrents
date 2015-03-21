using System;
using System.Collections.Generic;

namespace RssTorrents
{
	public interface IConfigReader
	{
		RssTorrentsConfiguration ReadConfiguration();
		void SaveConfiguration(RssTorrentsConfiguration config);
	}
}

