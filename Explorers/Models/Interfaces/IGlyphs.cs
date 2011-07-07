using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IGlyphs
	{
		List<Glyph> prime { get; set; }
		List<Glyph> major { get; set; }
		List<Glyph> minor { get; set; }
	}
}
