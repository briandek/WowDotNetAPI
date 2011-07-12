using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Explorers.CharacterExplorerModels
{
	public class Equipment
	{
		public int averageItemLevel { get; set; }
		public int averageItemLevelEquipped { get; set; }
		public Item head { get; set; }
		public Item neck { get; set; }
		public Item shoulder { get; set; }
		public Item back { get; set; }
		public Item chest { get; set; }
		public Item shirt { get; set; }
		public Item tabard { get; set; }
		public Item wrist { get; set; }
		public Item hands { get; set; }
		public Item waist { get; set; }
		public Item legs { get; set; }
		public Item feet { get; set; }
		public Item finger1 { get; set; }
		public Item finger2 { get; set; }
		public Item trinket1 { get; set; }
		public Item trinket2 { get; set; }
		public Item mainHand { get; set; }
		public Item offHand { get; set; }
		public Item ranged { get; set; }
	}
}
