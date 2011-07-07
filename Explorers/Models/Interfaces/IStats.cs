using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WowDotNetAPI.Explorers.Models.Interfaces
{
	public interface IStats
	{
		int health { get; set; }
		string powerType { get; set; }
		int power { get; set; }
		int str { get; set; }
		int agi { get; set; }
		int sta { get; set; }
		int @int { get; set; }
		int spr { get; set; }
		int attackPower { get; set; }
		int rangedAttackPower { get; set; }
		double mastery { get; set; }
		int masteryRating { get; set; }
		double crit { get; set; }
		int critRating { get; set; }
		double hitPercent { get; set; }
		int hitRating { get; set; }
		int hasteRating { get; set; }
		int expertiseRating { get; set; }
		int spellPower { get; set; }
		int spellPen { get; set; }
		double spellCrit { get; set; }
		int spellCritRating { get; set; }
		double spellHitPercent { get; set; }
		int spellHitRating { get; set; }
		double mana5 { get; set; }
		double mana5Combat { get; set; }
		int armor { get; set; }
		double dodge { get; set; }
		int dodgeRating { get; set; }
		double parry { get; set; }
		int parryRating { get; set; }
		double block { get; set; }
		int blockRating { get; set; }
		int resil { get; set; }
		double mainHandDmgMin { get; set; }
		double mainHandDmgMax { get; set; }
		double mainHandSpeed { get; set; }
		double mainHandDps { get; set; }
		int mainHandExpertise { get; set; }
		double offHandDmgMin { get; set; }
		double offHandDmgMax { get; set; }
		double offHandSpeed { get; set; }
		double offHandDps { get; set; }
		int offHandExpertise { get; set; }
		double rangedDmgMin { get; set; }
		double rangedDmgMax { get; set; }
		double rangedSpeed { get; set; }
		double rangedDps { get; set; }
		double rangedCrit { get; set; }
		int rangedCritRating { get; set; }
		double rangedHitPercent { get; set; }
		int rangedHitRating { get; set; }
	}
}
