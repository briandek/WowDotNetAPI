using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterArenaTeam
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "personalRating")]
        public int PersonalRating { get; set; }

        [DataMember(Name = "teamRating")]
        public int TeamRating { get; set; }

        [DataMember(Name = "size")]
        public string Size { get; set; }
    }
}
