using System;
using System.Collections.Generic;

namespace RssTorrents
{
	public class RssTorrentsConfiguration
	{
		public List<RssFeed> Feeds {get; set;}
		
		public RssTorrentsConfiguration ()
		{
			Feeds = new List<RssFeed>();
		}
	}
}

