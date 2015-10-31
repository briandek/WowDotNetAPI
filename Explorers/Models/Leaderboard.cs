using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public enum Bracket
    {
        _2v2,
        _3v3,
        _5v5,
        rbg
    }

    [DataContract]
    public class Leaderboard
    {
        [DataMember(Name = "rows")]
        public IEnumerable<PvpStats> PvpStats { get; set; }
    }
}
