using System;
using Gtk;

namespace RssTorrents
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			var shows = new ShowStatus (new RssFeed ("http://www.google.com"));
			shows.CheckRssFeed ();

			RssFetcher fetch = new RssFetcher ();

			var result = fetch.RssFeedExists ("http://www.google.com");

			if (result) {
				return;
			}

			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
