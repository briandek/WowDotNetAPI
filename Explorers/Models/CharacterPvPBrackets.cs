using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterPvPBrackets
    {
        [DataMember(Name = "ARENA_BRACKET_2v2")]
        public CharacterPvPBracket ArenaBracket2v2 { get; set; }

        [DataMember(Name = "ARENA_BRACKET_3v3")]
        public CharacterPvPBracket ArenaBracket3v3 { get; set; }

        [DataMember(Name = "ARENA_BRACKET_RBG")]
        public CharacterPvPBracket ArenaBracketRBG { get; set; }

        [DataMember(Name = "ARENA_BRACKET_2v2_SKIRMISH")]
        public CharacterPvPBracket ArenaBracket2v2Skirmish { get; set; }
    }
}
