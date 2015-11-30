using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class Spell
    {
        [DataMember(Name = "id")]
        public int SpellId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "range")]
        public string Range { get; set; }

        [DataMember(Name = "powerCost")]
        public string PowerCost { get; set; }

        [DataMember(Name = "castTime")]
        public string CastTime { get; set; }

        [DataMember(Name = "cooldown")]
        public string Cooldown { get; set; }

    }
}
