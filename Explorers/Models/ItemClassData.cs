using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class ItemClassData
    {
        [DataMember(Name = "classes")]
        public IEnumerable<ItemClassInfo> Classes { get; set; }
    }

}
