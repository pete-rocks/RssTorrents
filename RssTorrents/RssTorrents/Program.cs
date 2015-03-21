using System;

namespace RssTorrents
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Starting download...");

			var feed1 = new RssFeed ("12 Monkeys", "http://showrss.info/rss.php?user_id=240668&hd=null&proper=null&magnets=false&raw=true");
			feed1.Update();
			feed1.DownloadNewShows ();

			Console.WriteLine ("Downloaded!");
		}
	}
}
