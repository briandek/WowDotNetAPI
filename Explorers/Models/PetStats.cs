using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class PetStats
    {
        [DataMember(Name = "breedId")]
        public int BreedId { get; set; }

        [DataMember(Name = "health")]
        public int Health { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "petQualityId")]
        public int QualityId { get; set; }

        [DataMember(Name = "power")]
        public int Power { get; set; }

        [DataMember(Name = "speciesId")]
        public int SpeciesId { get; set; }

        [DataMember(Name = "speed")]
        public int Speed { get; set; }
    }
}
