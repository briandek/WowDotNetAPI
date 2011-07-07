using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models.Interfaces;

namespace WowDotNetAPI.Explorers.Models
{
	public class Achievements : IAchievements
	{
		public long[] achievementsCompleted { get; set; }
		public long[] achievementsCompletedTimestamp { get; set; }
		public long[] criteria { get; set; }
		public long[] criteriaQuantity { get; set; }
		public long[] criteriaTimestamp { get; set; }
		public long[] criteriaCreated { get; set; }
	}
}
