using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class PetAbilityDetails
    {
        [DataMember(Name = "id")]
        public int AbilityId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "cooldown")]
        public int Cooldown { get; set; }

        [DataMember(Name = "rounds")]
        public int Rounds { get; set; }

        [DataMember(Name = "petTypeId")]
        public int PetTypeId { get; set; }

        [DataMember(Name = "isPassive")]
        public bool IsPassive { get; set; }

        [DataMember(Name = "hideHints")]
        public bool HideHints { get; set; }
    }
}
