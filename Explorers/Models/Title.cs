using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WowDotNetAPI.Explorers.Models.Interfaces;

namespace WowDotNetAPI.Explorers.Models
{
	public class Title : ITitle
	{
		public int id { get; set; }
		public string name { get; set; }
	}
}
