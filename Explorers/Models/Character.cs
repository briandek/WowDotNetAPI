using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Explorers.Models
{
	public class Character
	{
		public string lastModified { get; set; }
		public string name { get; set; }
		public string realm { get; set; }
		public int @class { get; set; }
		public int race { get; set; }
		public int gender { get; set; }
		public int level { get; set; }
		public int achievementPoints { get; set; }
		public string thumbnail { get; set; }
		public Guild guild { get; set; }
		public Equipment items { get; set; }
		public Stats stats { get; set; }
		public Professions professions { get; set; }
		public List<Reputation> reputation { get; set; }
		public List<Title> titles { get; set; }
		public Achievements achievements { get; set; }
		public List<TalentSpecialization> talents { get; set; }
		public Appearance appearance { get; set; }
		public int[] mounts { get; set; }
		public int[] companions { get; set; }
		public Progression progression { get; set; }
	}
}
