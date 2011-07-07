using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IEquipment
	{
		int averageItemLevel { get; set; }
		int averageItemLevelEquipped { get; set; }
		Item head { get; set; }
		Item neck { get; set; }
		Item shoulder { get; set; }
		Item back { get; set; }
		Item chest { get; set; }
		Item shirt { get; set; }
		Item tabard { get; set; }
		Item wrist { get; set; }
		Item hands { get; set; }
		Item waist { get; set; }
		Item legs { get; set; }
		Item feet { get; set; }
		Item finger1 { get; set; }
		Item finger2 { get; set; }
		Item trinket1 { get; set; }
		Item trinket2 { get; set; }
		Item mainHand { get; set; }
		Item offHand { get; set; }
		Item ranged { get; set; }
	}
}
