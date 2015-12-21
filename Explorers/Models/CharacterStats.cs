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
        private string _powerType { get; set; }

        [DataMember(Name = "power")]
        public int Power { get; set; }

        [DataMember(Name = "str")]
        public int Strength { get; set; }

        [DataMember(Name = "agi")]
        public int Agility { get; set; }

        [DataMember(Name = "int")]
        public int Intellect { get; set; }

        [DataMember(Name = "sta")]
        public int Stamina { get; set; }

        [DataMember(Name = "speedRating")]
        public double SpeedRating { get; set; }

        [DataMember(Name = "speedRatingBonus")]
        public double SpeedRatingBonus { get; set; }

        [DataMember(Name = "crit")]
        public double Crit { get; set; }

        [DataMember(Name = "critRating")]
        public double CritRating { get; set; }

        [DataMember(Name = "haste")]
        public double Haste { get; set; }

        [DataMember(Name = "hasteRating")]
        public double HasteRating { get; set; }

        [DataMember(Name = "hasteRatingPercent")]
        public double HasteRatingPercent { get; set; }

        [DataMember(Name = "mastery")]
        public double Mastery { get; set; }

        [DataMember(Name = "masteryRating")]
        public double MasteryRating { get; set; }

        [DataMember(Name = "spr")]
        public int Spr { get; set; }

        [DataMember(Name = "bonusArmor")]
        public int BonusArmor { get; set; }

        [DataMember(Name = "multistrike")]
        public double Multistrike { get; set; }

        [DataMember(Name = "multistrikeRating")]
        public double MultistrikeRating { get; set; }

        [DataMember(Name = "multistrikeRatingBonus")]
        public double MultistrikeRatingBonus { get; set; }

        [DataMember(Name = "leech")]
        public double Leech { get; set; }

        [DataMember(Name = "leechRating")]
        public double LeechRating { get; set; }

        [DataMember(Name = "leechRatingBonus")]
        public double LeechRatingBonus { get; set; }

        [DataMember(Name = "versatility")]
        public int Versatility { get; set; }

        [DataMember(Name = "versatilityDamageDoneBonus")]
        public double VersatilityDamageDoneBonus { get; set; }

        [DataMember(Name = "versatilityHealingDoneBonus")]
        public double VersatilityHealingDoneBonus { get; set; }

        [DataMember(Name = "versatilityDamageTakenBonus")]
        public double VersatilityDamageTakenBonus { get; set; }

        [DataMember(Name = "avoidanceRating")]
        public double AvoidanceRating { get; set; }

        [DataMember(Name = "avoidanceRatingBonus")]
        public double AvoidanceRatingBonus { get; set; }

        [DataMember(Name = "spellPower")]
        public int SpellPower { get; set; }

        [DataMember(Name = "spellPen")]
        public int SpellPenetration { get; set; }

        [DataMember(Name = "spellCrit")]
        public double SpellCrit { get; set; }

        [DataMember(Name = "spellCritRating")]
        public double SpellCritRating { get; set; }

        [DataMember(Name = "mana5")]
        public double Mana5 { get; set; }

        [DataMember(Name = "mana5Combat")]
        public double Mana5Combat { get; set; }

        [DataMember(Name = "armor")]
        public int Armor { get; set; }

        [DataMember(Name = "dodge")]
        public double Dodge { get; set; }

        [DataMember(Name = "dodgeRating")]
        public int DodgeRating { get; set; }

        [DataMember(Name = "parry")]
        public double Parry { get; set; }

        [DataMember(Name = "parryRating")]
        public int ParryRating { get; set; }

        [DataMember(Name = "block")]
        public double Block { get; set; }

        [DataMember(Name = "blockRating")]
        public int BlockRating { get; set; }
        
        [DataMember(Name = "mainHandDmgMin")]
        public double MainHandDmgMin { get; set; }

        [DataMember(Name = "mainHandDmgMax")]
        public double MainHandDmgMax { get; set; }

        [DataMember(Name = "mainHandSpeed")]
        public double MainHandSpeed { get; set; }

        [DataMember(Name = "mainHandDps")]
        public double MainHandDps { get; set; }
        
        [DataMember(Name = "offHandDmgMin")]
        public double OffHandDmgMin { get; set; }

        [DataMember(Name = "offHandDmgMax")]
        public double OffHandDmgMax { get; set; }

        [DataMember(Name = "offHandSpeed")]
        public double OffHandSpeed { get; set; }

        [DataMember(Name = "offHandDps")]
        public double OffHandDps { get; set; }
        
        [DataMember(Name = "rangedDmgMin")]
        public double RangedDmgMin { get; set; }

        [DataMember(Name = "rangedDmgMax")]
        public double RangedDmgMax { get; set; }

        [DataMember(Name = "rangedSpeed")]
        public double RangedSpeed { get; set; }

        [DataMember(Name = "rangedDps")]
        public double RangedDps { get; set; }
        
        [DataMember(Name = "attackPower")]
        public int AttackPower { get; set; }

        [DataMember(Name = "rangedAttackPower")]
        public int RangedAttackPower { get; set; }


        public CharacterPowerType PowerType { get { return (CharacterPowerType)Enum.Parse(typeof(CharacterPowerType), _powerType.Replace("-", string.Empty), true); } }

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
