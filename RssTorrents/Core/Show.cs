using System;

namespace RssTorrents
{
	public class Show
	{
		public readonly string TorrentUrl;
		public readonly string EpisodeName;
		
		public Show (string torrentUrl, string episodeName)
		{
			TorrentUrl = torrentUrl;
			EpisodeName = episodeName;
		}
	}
}

