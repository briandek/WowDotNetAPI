using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models.Interfaces;

namespace WowDotNetAPI.Explorers.Models
{
	public class Professions : IProfessions
	{
		public List<Profession> primary { get; set; }
		public List<Profession> secondary { get; set; }
	}
}
