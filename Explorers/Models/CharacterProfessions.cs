using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Models
{
	public class CharacterProfessions
	{
		public IEnumerable<CharacterProfession> primary { get; set; }
        public IEnumerable<CharacterProfession> secondary { get; set; }
	}
}
