using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface ICharacter
	{
		string lastModified { get; set; }
		string name { get; set; }
		string realm { get; set; }
		int characterClass { get; set; }
		int race { get; set; }
		int gender { get; set; }
		int level { get; set; }
		int achievementPoints { get; set; }
		string thumbnail { get; set; }
		Guild guild { get; set; }
	}
}
