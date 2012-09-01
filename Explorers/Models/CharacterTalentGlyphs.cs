using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
	public class CharacterTalentGlyphs
	{
        [DataMember(Name = "major")]
        public IEnumerable<CharacterTalentGlyph> Major { get; set; }

        [DataMember(Name = "minor")]
        public IEnumerable<CharacterTalentGlyph> Minor { get; set; }
	}
}
