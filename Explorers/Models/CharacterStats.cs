using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterStats : IEnumerable
    {
        [DataMember(Name = "health")]
        public int Health { get; set; }

        [DataMember(Name = "powerType")]
        private string powerType { get; set; }

        [DataMember(Name = "power")]
        public int Power { get; set; }

        [DataMember(Name = "str")]
        public int Str { get; set; }

        [DataMember(Name = "agi")]
        public int Agi { get; set; }

        [DataMember(Name = "sta")]
        public int Sta { get; set; }
        
        [DataMember(Name = "int")]
        public int @Int { get; set; }

        [DataMember(Name = "spr")]
        public int Spr { get; set; }

        [DataMember(Name = "attackPower")]
        public int AttackPower { get; set; }

        [DataMember(Name = "rangedAttackPower")]
        public int RangedAttackPower { get; set; }

        [DataMember(Name = "mastery")]
        public double Mastery { get; set; }

        [DataMember(Name = "masteryRating")]
        public double MasteryRating { get; set; }

        [DataMember(Name = "crit")]
        public double Crit { get; set; }

        [DataMember(Name = "critRating")]
		public double CritRating { get; set; }

        [DataMember(Name = "hitPercent")]
        public double HitPercent { get; set; }

        [DataMember(Name = "hitRating")]
        public double HitRating { get; set; }

        [DataMember(Name = "haste")]
        public double Haste { get; set; }

        [DataMember(Name = "hasteRating")]
		public double HasteRating { get; set; }

        [DataMember(Name = "hasteRatingPercent")]
        public double HasteRatingPercent { get; set; }

        [DataMember(Name = "expertiseRating")]
		public double ExpertiseRating { get; set; }

        [DataMember(Name = "spellPower")]
        public int SpellPower { get; set; }

        [DataMember(Name = "spellPen")]
        public int SpellPenetration { get; set; }

        [DataMember(Name = "spellCrit")]
        public double SpellCrit { get; set; }

        [DataMember(Name = "spellCritRating")]
		public double SpellCritRating { get; set; }

        [DataMember(Name = "spellHaste")]
        public double SpellHaste { get; set; }

        [DataMember(Name = "spellHasteRating")]
        public double SpellHasteRating { get; set; }

        [DataMember(Name = "spellHasteRatingPercent")]
        public double SpellHasteRatingPercent { get; set; }

        [DataMember(Name = "spellHitPercent")]
        public double SpellHitPercent { get; set; }

        [DataMember(Name = "spellHitRating")]
		public double SpellHitRating { get; set; }

        [DataMember(Name = "mana5")]
        public double Mana5 { get; set; }

        [DataMember(Name = "mana5Combat")]
        public double Mana5Combat { get; set; }

        [DataMember(Name = "armor")]
        public int Armor { get; set; }

        [DataMember(Name = "dodge")]
        public double Dodge { get; set; }

        [DataMember(Name = "dodgeRating")]
		public double DodgeRating { get; set; }

        [DataMember(Name = "parry")]
        public double Parry { get; set; }

        [DataMember(Name = "parryRating")]
		public double ParryRating { get; set; }

        [DataMember(Name = "block")]
        public double Block { get; set; }

        [DataMember(Name = "blockRating")]
        public double BlockRating { get; set; }

        [DataMember(Name = "pvpResilience")]
        public double PvpResilience { get; set; }

        [DataMember(Name = "pvpResilienceBonus")]
        public double PvPResilienceBonus { get; set; }

        [DataMember(Name = "pvpResilienceRating")]
        public int PvpResilienceRating { get; set; }

        [DataMember(Name = "pvpPower")]
        public double PvpPower { get; set; }

        [DataMember(Name = "pvpPowerDamage")]
        public double PvPPowerDamage { get; set; }

        [DataMember(Name = "pvpPowerHealing")]
        public Double PvPPowerHealing { get; set; }

        [DataMember(Name = "pvpPowerRating")]
        public int PvpPowerRating { get; set; }

        [DataMember(Name = "mainHandDmgMin")]
        public double MainHandDmgMin { get; set; }

        [DataMember(Name = "mainHandDmgMax")]
        public double MainHandDmgMax { get; set; }

        [DataMember(Name = "mainHandSpeed")]
        public double MainHandSpeed { get; set; }

        [DataMember(Name = "mainHandDps")]
        public double MainHandDps { get; set; }

        [DataMember(Name = "mainHandExpertise")]
        public double MainHandExpertise { get; set; }

        [DataMember(Name = "offHandDmgMin")]
        public double OffHandDmgMin { get; set; }

        [DataMember(Name = "offHandDmgMax")]
        public double OffHandDmgMax { get; set; }

        [DataMember(Name = "offHandSpeed")]
        public double OffHandSpeed { get; set; }

        [DataMember(Name = "offHandDps")]
        public double OffHandDps { get; set; }

        [DataMember(Name = "offHandExpertise")]
        public double OffHandExpertise { get; set; }

        [DataMember(Name = "rangedDmgMin")]
        public double RangedDmgMin { get; set; }

        [DataMember(Name = "rangedDmgMax")]
        public double RangedDmgMax { get; set; }

        [DataMember(Name = "rangedSpeed")]
        public double RangedSpeed { get; set; }

        [DataMember(Name = "rangedDps")]
        public double RangedDps { get; set; }

        [DataMember(Name = "rangedExpertise")]
        public double RangedExpertise { get; set; }

        [DataMember(Name = "rangedHaste")]
        public double RangedHaste { get; set; }

        [DataMember(Name = "rangedHasteRating")]
        public double RangedHasteRating { get; set; }

        [DataMember(Name = "rangedHasteRatingPercent")]
        public double RangedHasteRatingPercent { get; set; }

        [DataMember(Name = "rangedCrit")]
        public double RangedCrit { get; set; }

        [DataMember(Name = "rangedCritRating")]
        public double RangedCritRating { get; set; }

        [DataMember(Name = "rangedHitPercent")]
        public double RangedHitPercent { get; set; }

        [DataMember(Name = "rangedHitRating")]
		public double RangedHitRating { get; set; }



        public CharacterPowerType PowerType { get { return (CharacterPowerType)Enum.Parse(typeof(CharacterPowerType), powerType.Replace("-", string.Empty), true); } }

        //http://stackoverflow.com/questions/1447308/enumerating-through-an-objects-properties-string-in-c
        //TODO:REFACTOR THIS / possible performance issue
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
