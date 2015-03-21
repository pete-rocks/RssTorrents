using System;
using Gtk;

namespace RssTorrents
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var feed1 = new RssFeed ("12 Monkeys", "http://showrss.info/rss.php?user_id=240668&hd=null&proper=null&magnets=false&raw=true");
			feed1.Update();
			feed1.DownloadNewShows ();


			//RssFetcher fetch = new RssFetcher ();

			//var result = fetch.RssFeedExists ("http://showrss.info/feeds/350.rss");

			//if (result) {
			//	return;
			//}


			return;

			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
