namespace RssTorrents
{
	public class Show
	{
		public string TorrentUrl {get; private set;}
		public string EpisodeName {get; private set;}
		
		public Show (string torrentUrl, string episodeName)
		{
			TorrentUrl = torrentUrl;
			EpisodeName = episodeName;
		}
	}
}

