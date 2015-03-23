using System;
using System.Threading.Tasks;

namespace RssTorrents
{
	public interface IRssFeed : IService
	{
		void Update();
		Task DownloadNewShows();
	}
}

