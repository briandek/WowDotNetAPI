using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
	public class CharacterProfessions
	{
        [DataMember(Name="primary")]
		public IEnumerable<CharacterProfession> Primary { get; set; }

        [DataMember(Name = "secondary")]
        public IEnumerable<CharacterProfession> Secondary { get; set; }
	}
}
