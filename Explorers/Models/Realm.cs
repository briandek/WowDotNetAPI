using System;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models
{

	//Realm API simple doc reference. Author: Cyaga - http://us.battle.net/wow/en/forum/topic/2416192911
	//Realm 
	//name: string, the fully formatted name of the realm
	//slug: string, "data-friendly" version of name, punctuation removed and spaces converted to dashes
	//type: string, type of the realm: pve, pvp, rp, rppvp
	//status: boolean, true if realm is up, false otherwise
	//queue: boolean, true if realm has a queue, false otherwise
	//population: string, the realm's population: low, medium, high, n/a

	public class Realm
	{
		public string type { get; set; }
		public bool queue { get; set; }
		public bool status { get; set; }
		public string population { get; set; }
		public string name { get; set; }
		public string slug { get; set; }
	}
}
