using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IProfessions
	{
		List<Profession> primary { get; set; }
		List<Profession> secondary { get; set; }
	}
}
