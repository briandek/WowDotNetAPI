using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IAppearance
	{
		int faceVariation { get; set; }
		int skinColor { get; set; }
		int hairVariation { get; set; }
		int hairColor { get; set; }
		int featureVariation { get; set; }
		bool showHelm { get; set; }
		bool showCloak { get; set; }
	}
}
