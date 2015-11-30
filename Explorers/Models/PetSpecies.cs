using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class PetSpecies
    {
        [DataMember(Name = "speciesId")]
        public int SpeciesId { get; set; }

        [DataMember(Name = "petTypeId")]
        public int PetTypeId { get; set; }

        [DataMember(Name = "creatureId")]
        public int CreatureId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "canBattle")]
        public bool CanBattle { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "source")]
        public string Source { get; set; }

        [DataMember(Name = "abilities")]
        public IEnumerable<PetAbility> Abilities { get; set; }
    }
}
