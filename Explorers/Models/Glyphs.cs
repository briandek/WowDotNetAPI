using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models.Interfaces;

namespace WowDotNetAPI.Explorers.Models
{
	public class Glyphs : IGlyphs
	{
		public List<Glyph> prime { get; set; }
		public List<Glyph> major { get; set; }
		public List<Glyph> minor { get; set; }
	}
}
