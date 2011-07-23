using System;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public enum RealmType
    {
        [EnumMember(Value = "pve")]
        PVE,
        [EnumMember(Value = "pvp")]
        PVP,
        [EnumMember(Value = "rp")]
        RP,
        [EnumMember(Value = "rppvp")]
        RPPVP
    }

    [DataContract]
    public enum RealmPopulation
    {
        [EnumMember(Value = "low")]
        LOW,
        [EnumMember(Value = "medium")]
        MEDIUM,
        [EnumMember(Value = "high")]
        HIGH,
        [EnumMember(Value = "n/a")]
        NA
    }

    [DataContract]
    public class Realm
    {
        [DataMember(Name = "type")]
        private string type { get; set; }

        [DataMember(Name = "queue")]
        public bool Queue { get; set; }

        [DataMember(Name = "status")]
        public bool Status { get; set; }

        [DataMember(Name = "population")]
        private string population { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        public RealmType Type { get { return (RealmType)Enum.Parse(typeof(RealmType), type, true); } }
        
        public RealmPopulation Population { get { return (RealmPopulation)Enum.Parse(typeof(RealmPopulation), population, true); } }

        //refactor
        //private T GetEnumValue<T>(string s)
        //{
        //    return (T)Enum.Parse(typeof(T), s, true);
        //}
    }
}
