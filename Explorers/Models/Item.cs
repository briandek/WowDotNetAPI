using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class Item
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "nameDescription")]
        public string NameDescription { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "stackable")]
        public int Stackable { get; set; }

        [DataMember(Name = "allowableClasses")]
        public IEnumerable<int> AllowableClasses { get; set; }

        [DataMember(Name = "itemBind")]
        public int ItemBind { get; set; }

        [DataMember(Name = "bonusStats")]
        public IEnumerable<ItemBonusStat> BonusStats { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "itemSpells")]
        public IEnumerable<ItemSpellInfo> ItemSpells { get; set; }

        [DataMember(Name = "buyPrice")]
        public int BuyPrice { get; set; }

        [DataMember(Name = "itemClass")]
        public int ItemClass { get; set; }

        [DataMember(Name = "itemSubClass")]
        public int ItemSubClass { get; set; }

        [DataMember(Name = "containerSlots")]
        public int ContainerSlots { get; set; }

        [DataMember(Name = "gemInfo")]
        public ItemGemInfo GemInfo { get; set; }

        [DataMember(Name = "weaponInfo")]
        public ItemWeaponInfo WeaponInfo { get; set; }

        [DataMember(Name = "inventoryType")]
        public int InventoryType { get; set; }

        [DataMember(Name = "equippable")]
        public bool Equippable { get; set; }

        [DataMember(Name = "itemLevel")]
        public int ItemLevel { get; set; }

        [DataMember(Name = "maxCount")]
        public int MaxCount { get; set; }

        [DataMember(Name = "maxDurability")]
        public int MaxDurability { get; set; }

        [DataMember(Name = "minFactionId")]
        public int MinFactionId { get; set; }

        [DataMember(Name = "minReputation")]
        public int MinReputation { get; set; }

        [DataMember(Name = "quality")]
        public int Quality { get; set; }

        [DataMember(Name = "sellPrice")]
        public int SellPrice { get; set; }

        [DataMember(Name = "requiredSkill")]
        public int RequiredSkill { get; set; }

        [DataMember(Name = "requiredLevel")]
        public int RequiredLevel { get; set; }
         
        [DataMember(Name = "requiredSkillRank")]
        public int RequiredSkillRank { get; set; }

        [DataMember(Name = "socketInfo")]
        public ItemSocketInfo SocketInfo { get; set; }

        [DataMember(Name = "itemSource")]
        public ItemSourceInfo ItemSource { get; set; }

        [DataMember(Name = "baseArmor")]
        public int BaseArmor { get; set; }

        [DataMember(Name = "hasSockets")]
        public bool HasSockets { get; set; }

        [DataMember(Name = "isAuctionable")]
        public bool IsAuctionable { get; set; }

        [DataMember(Name = "upgradable")]
        public bool Upgradable { get; set; }

        [DataMember(Name = "disenchantingSkillRank")]
        public int DisenchantingSkillRank { get; set; }

        [DataMember(Name = "displayInfoId")]
        public int DisplayInfoId { get; set; }

        [DataMember(Name = "heroicTooltip")]
        public bool HeroicTooltip { get; set; }

        [DataMember(Name = "nameDescriptionColor")]
        public string NameDescriptionColor { get; set; }

    }
}
