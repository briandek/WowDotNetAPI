using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface ITalentSpecialization
	{
		bool selected { get; set; }
		string name { get; set; }
		string icon { get; set; }
		string build { get; set; }
		List<TalentTree> trees { get; set; }
		Glyphs glyphs { get; set; }
	}
}
