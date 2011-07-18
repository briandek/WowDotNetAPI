using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace WowDotNetAPI.Models
{
    public class CharacterStats : IEnumerable
    {
        public int health { get; set; }
        public string powerType { get; set; }
        public int power { get; set; }
        public int str { get; set; }
        public int agi { get; set; }
        public int sta { get; set; }
        public int @int { get; set; }
        public int spr { get; set; }
        public int attackPower { get; set; }
        public int rangedAttackPower { get; set; }
        public double mastery { get; set; }
        public int masteryRating { get; set; }
        public double crit { get; set; }
        public int critRating { get; set; }
        public double hitPercent { get; set; }
        public int hitRating { get; set; }
        public int hasteRating { get; set; }
        public int expertiseRating { get; set; }
        public int spellPower { get; set; }
        public int spellPen { get; set; }
        public double spellCrit { get; set; }
        public int spellCritRating { get; set; }
        public double spellHitPercent { get; set; }
        public int spellHitRating { get; set; }
        public double mana5 { get; set; }
        public double mana5Combat { get; set; }
        public int armor { get; set; }
        public double dodge { get; set; }
        public int dodgeRating { get; set; }
        public double parry { get; set; }
        public int parryRating { get; set; }
        public double block { get; set; }
        public int blockRating { get; set; }
        public int resil { get; set; }
        public double mainHandDmgMin { get; set; }
        public double mainHandDmgMax { get; set; }
        public double mainHandSpeed { get; set; }
        public double mainHandDps { get; set; }
        public int mainHandExpertise { get; set; }
        public double offHandDmgMin { get; set; }
        public double offHandDmgMax { get; set; }
        public double offHandSpeed { get; set; }
        public double offHandDps { get; set; }
        public int offHandExpertise { get; set; }
        public double rangedDmgMin { get; set; }
        public double rangedDmgMax { get; set; }
        public double rangedSpeed { get; set; }
        public double rangedDps { get; set; }
        public double rangedCrit { get; set; }
        public int rangedCritRating { get; set; }
        public double rangedHitPercent { get; set; }
        public int rangedHitRating { get; set; }


        //http://stackoverflow.com/questions/1447308/enumerating-through-an-objects-properties-string-in-c
        //TODO:REFACTOR THIS / possible performance issue
        //TODO: sort out Camelcase / Pascal case -> serializing/deserializing 
        public IEnumerator GetEnumerator()
        {
            IEnumerable<KeyValuePair<string, object>> tmp = 
                this.GetType()
                .GetProperties()
                .Select(pi => new KeyValuePair<string, object>( pi.Name, pi.GetGetMethod().Invoke(this, null)));

            return tmp.GetEnumerator();
        }
    }
}
