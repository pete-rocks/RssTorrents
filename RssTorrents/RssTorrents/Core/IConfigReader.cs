using System;
using System.Collections.Generic;

namespace RssTorrents
{
	public interface IConfigReader
	{
		List<RssFeed> ReadFeeds();
	}
}

