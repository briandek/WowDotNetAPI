using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models
{
	public class Glyphs
	{
		public List<Glyph> prime { get; set; }
		public List<Glyph> major { get; set; }
		public List<Glyph> minor { get; set; }
	}
}
