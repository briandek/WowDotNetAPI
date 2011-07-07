using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IAchievements
	{
		long[] achievementsCompleted { get; set; }
		long[] achievementsCompletedTimestamp { get; set; }
		long[] criteria { get; set; }
		long[] criteriaQuantity { get; set; }
		long[] criteriaTimestamp { get; set; }
		long[] criteriaCreated { get; set; }
	}
}
