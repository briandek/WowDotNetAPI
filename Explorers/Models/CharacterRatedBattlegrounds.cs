using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterRatedBattlegrounds
    {
        [DataMember(Name = "personalRating")]
        public int PersonalRating { get; set; }

        [DataMember(Name = "battlegrounds")]
        public IEnumerable<CharacterRatedBattleground> Battlegrounds { get; set; }
    }
}
