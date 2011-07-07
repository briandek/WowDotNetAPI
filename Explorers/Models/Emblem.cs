using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models.Interfaces;

namespace WowDotNetAPI.Explorers.Models
{
	public class Emblem : IEmblem
	{
		public int icon { get; set; }
		public string iconColor { get; set; }
		public int border { get; set; }
		public string borderColor { get; set; }
		public string backgroundcolor { get; set; }
	}
}
