using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Test;
using System.Collections;
using WowDotNetAPI.Models;
using WowDotNetAPI.Utilities;
using WowDotNetAPI;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class DataTests
    {
        private static WowExplorer explorer;
        private static string APIKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US, APIKey);
        }

        [TestMethod]
        public void Get_BattleGroups_Test()
        {
            var battleGroups = explorer.GetBattlegroupsData();

            Assert.AreEqual(9, battleGroups.Count()); 
            Assert.IsTrue(battleGroups.Any(r => r.Name == "Rampage"));
        }

        [TestMethod]
        public void Get_Character_Races_Data()
        {
            var races = explorer.GetCharacterRaces();

            Assert.AreEqual(15, races.Count());
            Assert.IsTrue(races.Any(r => r.Name == "Human" || r.Name == "Night Elf"));
        }

        [TestMethod]
        public void Get_Character_Achievements_Data()
        {
            var characterAchievements = explorer.GetAchievements();

            Assert.AreEqual(15, characterAchievements.Count());
            var achievementList = characterAchievements.First<AchievementList>(a => a.Id == 92);
            var gotMyMindOnMyMoneyAchievement = achievementList.Achievements.First<AchievementInfo>(a => a.Id == 1181);
            Assert.AreEqual("Loot 25,000 gold", gotMyMindOnMyMoneyAchievement.Criteria.ElementAt(0).Description);

        }

        [TestMethod]
        public void Get_Character_Classes_Data()
        {
            var classes = explorer.GetCharacterClasses();

            Assert.AreEqual(classes.Count(), 12);
            Assert.IsTrue(classes.Any(r => r.Name == "Warrior" || r.Name == "Death Knight"));
        }

        [TestMethod]
        public void Get_Guild_Achievements_Data()
        {
            var guildAchievementsList = explorer.GetGuildAchievements();
            Assert.AreEqual(7, guildAchievementsList.Count());
        }

        [TestMethod]
        public void Get_Guild_Rewards_Data()
        {
            var rewards = explorer.GetGuildRewards();
            Assert.AreEqual(64, rewards.Count());
            Assert.IsTrue(rewards.Any(r => r.Achievement != null));
        }


        [TestMethod]
        public void Get_Guild_Perks_Data()
        {
            var perks = explorer.GetGuildPerks();
            Assert.AreEqual(5, perks.Count());
            Assert.IsTrue(perks.Any(r => r.Spell != null));
        }

        [TestMethod]
        public void Get_Realms_From_Json_String()
        {
            var realms1 = explorer.GetRealms();
            var realms2 = JsonUtility.FromJSONString<RealmsData>(TestStrings.TestRealms).Realms;
            var realms3 = realms1.Intersect(realms2);
            Assert.AreEqual(0, realms3.Count());

        }

        [TestMethod]
        public void Get_Item_Classes()
        {
            var itemClasses = explorer.GetItemClasses();
            Assert.AreEqual(16, itemClasses.Count());

        }

    }

}
