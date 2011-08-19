using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class ItemSourceInfo
    {
        [DataMember(Name = "sourceId")]
        public int SourceId { get; set; }

        [DataMember(Name = "sourceType")]
        public string SourceType { get; set; }
    }
}
