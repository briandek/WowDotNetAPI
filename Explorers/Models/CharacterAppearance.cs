using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
	public class CharacterAppearance
	{
        [DataMember(Name = "faceVariation")]
		public int FaceVariation { get; set; }

        [DataMember(Name = "skinColor")]
        public int SkinColor { get; set; }

        [DataMember(Name = "hairVariation")]
        public int HairVariation { get; set; }

        [DataMember(Name = "hairColor")]
        public int HairColor { get; set; }

        [DataMember(Name = "featureVariation")]
        public int FeatureVariation { get; set; }

        [DataMember(Name = "showHelm")]
        public bool ShowHelm { get; set; }

        [DataMember(Name = "showCloak")]
        public bool ShowCloak { get; set; }
	}
}
