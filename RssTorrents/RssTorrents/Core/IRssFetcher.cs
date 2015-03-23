using System.Collections.Generic;

namespace RssTorrents
{
	public interface IRssFetcher : IService
	{
		List<Show> GetAllShows(string feedUrl);
	}
}

