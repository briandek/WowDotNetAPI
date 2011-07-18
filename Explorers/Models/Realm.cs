using System;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
	public class Realm
	{
        [DataMember(Name = "type")]
		public string Type { get; set; }
        
        [DataMember(Name = "queue")]
        public bool Queue { get; set; }
        
        [DataMember(Name = "status")]
        public bool Status { get; set; }
        
        [DataMember(Name = "population")]
        public string Population { get; set; }
        
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "slug")]
        public string Slug { get; set; }
	}
}
