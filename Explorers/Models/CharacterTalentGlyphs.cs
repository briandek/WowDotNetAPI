using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Models
{
	public class CharacterTalentGlyphs
	{
        public IEnumerable<CharacterTalentGlyph> prime { get; set; }
        public IEnumerable<CharacterTalentGlyph> major { get; set; }
        public IEnumerable<CharacterTalentGlyph> minor { get; set; }
	}
}
