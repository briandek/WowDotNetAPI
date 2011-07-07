using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IRealm
	{
		string type { get; set; }
		bool queue { get; set; }
		bool status { get; set; }
		string population { get; set; }
		string name { get; set; }
		string slug { get; set; }		
	}
}
