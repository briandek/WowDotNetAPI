using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IProfession
	{
		int id { get; set; }
		string name { get; set; }
		string icon { get; set; }
		int rank { get; set; }
		int max { get; set; }
		int[] recipes { get; set; }
	}
}
