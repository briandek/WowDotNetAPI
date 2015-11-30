using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class Recipe
    {
        [DataMember(Name = "id")]
        public int RecipeId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "profession")]
        public string Profession { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }
    }
}
