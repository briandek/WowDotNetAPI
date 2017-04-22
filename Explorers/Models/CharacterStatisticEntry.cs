using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterStatisticEntry
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "quantity")]
        public long Quantity { get; set; }

        [DataMember(Name = "lastUpdated")]
        public long LastUpdated { get; set; }

        [DataMember(Name = "money")]
        public bool Money { get; set; }
    }
}
