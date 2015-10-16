using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public enum CharacterSpec
    {
        MAGE_ARCANE = 62,
        MAGE_FIRE = 63,
        MAKE_FROST = 64,
        PALADIN_HOLY = 65,
        PALADIN_PROTECTION = 66,
        PALADIN_RETRIBUTION = 70,
        WARRIOR_ARMS = 71,
        WARRIOR_FURY = 72,
        WARRIOR_PROTECTION = 73,
        PET_FEROCITY = 74,
        PET_CUNNING = 79,
        PET_TENACITY = 81,
        DRUID_BALANCE = 102,
        DRUID_FERAL = 103,
        DRUID_GUARDIAN = 104,
        DRUID_RESTOR = 105,
        DK_BLOOD = 250,
        DK_FROST = 251,
        DK_UNHOLY = 252,
        HUNTER_BEASTMASTER = 253,
        HUNTER_MARKSMAN = 254,
        HUNTER_SURVIVAL = 255,
        PRIEST_DISCIPLINE = 256,
        PRIEST_HOLY = 257,
        PRIEST_SHADOW = 258,
        ROGUE_ASSASSINATION = 259,
        ROGUE_COMBAT = 260,
        ROGUE_SUBTLETY = 261,
        SHAMAN_ELEMENTAL = 262,
        SHAMAN_ENHANCEMENT = 263,
        SHAMAN_RESTORATION = 264,
        WARLOCK_AFFLICTION = 265,
        WARLOCK_DEMONOLOGY = 266,
        WARLOCK_DESTRUCTION = 267,
        MONK_BREWMASTER = 268,
        MONK_WINDDANCER = 269,
        MONK_MISTWEAVER = 270,
        ADAPTATION_FEROCITY = 535,
        ADAPTATION_CUNNING = 536,
        ADAPTATION_TENACITY = 537
    }

    [DataContract]
    public class CharacterTalent
    {
        [DataMember(Name = "selected")]
        public bool Selected { get; set; }

        [DataMember(Name = "talents")]
        public IEnumerable<CharacterTalentInfo> Talents { get; set; }

        [DataMember(Name = "glyphs")]
        public CharacterTalentGlyphs Glyphs { get; set; }

        [DataMember(Name = "spec")]
        public CharacterTalentSpec Spec { get; set; }

        [DataMember(Name = "calcTalent")]
        public string CalcTalent { get; set; }

        [DataMember(Name = "calcSpec")]
        public string CalcSpec { get; set; }

        [DataMember(Name = "calcGlyph")]
        public string CalcGlyph { get; set; }
    }
}
