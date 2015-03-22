using System.Collections.Generic;

namespace RssTorrents
{
	public interface IRssFetcher
	{
		List<Show> GetAllShows(string feedUrl);
	}
}

