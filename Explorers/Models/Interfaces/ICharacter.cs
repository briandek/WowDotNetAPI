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
		int @class { get; set; }
		int race { get; set; }
		int gender { get; set; }
		int level { get; set; }
		int achievementPoints { get; set; }
		string thumbnail { get; set; }
		Guild guild { get; set; }
		Equipment items { get; set; }
		Stats stats { get; set; }
		Professions professions { get; set; }
		List<Reputation> reputation { get; set; }
		List<Title> titles { get; set; }
		Achievements achievements { get; set; }
		List<TalentSpecialization> talents { get; set; }
		Appearance appearance { get; set; }
		int[] mounts { get; set; }
		int[] companions { get; set; }
		Progression progression { get; set; }
	}
}
