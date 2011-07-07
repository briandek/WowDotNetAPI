using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models.Interfaces;

namespace WowDotNetAPI.Explorers.Models
{
	public class Appearance : IAppearance
	{
		public int faceVariation { get; set; }
		public int skinColor { get; set; }
		public int hairVariation { get; set; }
		public int hairColor { get; set; }
		public int featureVariation { get; set; }
		public bool showHelm { get; set; }
		public bool showCloak { get; set; }
	}
}
