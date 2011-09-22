 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public enum CharacterPowerType
    {
        [EnumMember(Value = "focus")]
        FOCUS,
        [EnumMember(Value = "rage")]
        RAGE,
        [EnumMember(Value = "mana")]
        MANA,
        [EnumMember(Value = "energy")]
        ENERGY,
        [EnumMember(Value = "runic-power")]
        RUNICPOWER
    }

    [DataContract]
    public class CharacterClassInfo
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "mask")]
        public int Mask { get; set; }

        [DataMember(Name = "powerType")]
        private string powerType { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        public CharacterPowerType PowerType { get { return (CharacterPowerType)Enum.Parse(typeof(CharacterPowerType), powerType.Replace("-", string.Empty), true); } }
    }
}
