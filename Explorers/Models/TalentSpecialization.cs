using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Explorers.CharacterExplorerModels
{
	public class TalentSpecialization
	{
		public bool selected { get; set; }
		public string name { get; set; }
		public string icon { get; set; }
		public string build { get; set; }
		public List<TalentTree> trees { get; set; }
		public Glyphs glyphs { get; set; }
	}
}
