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

    //TODO: sort out issue with enum member n/a . It seems there's an issue with the forward slash and how we serialize and the try to parse it
    //[DataContract]
    //public enum RealmPopulation
    //{
    //    [EnumMember(Value = "low")]
    //    LOW,
    //    [EnumMember(Value = "medium")]
    //    MEDIUM,
    //    [EnumMember(Value = "high")]
    //    HIGH,
    //    [EnumMember(Value = "n/a")]
    //    NA
    //}

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
        public string population { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        [DataMember(Name = "battlegroup")]
        public string Battlegroup { get; set; }

        [DataMember(Name = "locale")]
        public string Locale { get; set; }

        public RealmType Type { get { return (RealmType)Enum.Parse(typeof(RealmType), type, true); } }

        //See enum TODO comments
        //public RealmPopulation Population { get { return (RealmPopulation)Enum.Parse(typeof(RealmPopulation), population, true); } }

    }
}
