using System;

namespace RssTorrents
{
	public interface IRssFeed
	{
		void Update();
		void DownloadNewShows();

	}
}

