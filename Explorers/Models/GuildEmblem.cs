using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class GuildEmblem
    {
        [DataMember(Name = "icon")]
        public int Icon { get; set; }

        [DataMember(Name = "iconColor")]
        public string IconColor { get; set; }

        [DataMember(Name = "border")]
        public int Border { get; set; }

        [DataMember(Name = "borderColor")]
        public string BorderColor { get; set; }

        [DataMember(Name = "backgroundColor")]
        public string BackgroundColor { get; set; }
    }
}
