using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class Quest
    {
        [DataMember(Name = "id")]
        public int QuestId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "reqLevel")]
        public int RequiredLevel { get; set; }

        [DataMember(Name = "suggestedPartyMembers")]
        public int SuggestedPartyMembers { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }
    }
}
