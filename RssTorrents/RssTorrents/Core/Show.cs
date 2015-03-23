using System;

namespace RssTorrents
{
	public class Show
	{
		public string TorrentUrl {get; private set;}
		public string EpisodeName {get; private set;}
		public DateTime DatePublished {get; private set;}
		
		public Show (string torrentUrl, string episodeName, DateTime datePublished)
		{
			TorrentUrl = torrentUrl;
			EpisodeName = episodeName;
			DatePublished = datePublished;
		}
	}
}

