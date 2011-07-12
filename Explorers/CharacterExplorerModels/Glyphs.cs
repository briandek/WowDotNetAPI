using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.CharacterExplorerModels
{
	public class Glyphs
	{
        public IEnumerable<Glyph> prime { get; set; }
        public IEnumerable<Glyph> major { get; set; }
        public IEnumerable<Glyph> minor { get; set; }
	}
}
