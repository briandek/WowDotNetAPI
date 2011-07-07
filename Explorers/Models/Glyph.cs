using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models.Interfaces;

namespace WowDotNetAPI.Explorers.Models
{
	public class Glyph : IGlyph
	{
		public int glyph { get; set; }
		public int item { get; set; }
		public string name { get; set; }
		public string icon { get; set; }
	}
}
