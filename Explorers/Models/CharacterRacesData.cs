using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterRacesData
    {
        [DataMember(Name="races")]
        public IEnumerable<CharacterRaceInfo> Races { get; set; }
    }
}
