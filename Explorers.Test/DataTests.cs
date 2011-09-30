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
using WowDotNetAPI.Exceptions;
using WowDotNetAPI;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class DataTests
    {
        private static WowExplorer explorer;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US);
        }

        [TestMethod]
        public void Get_Character_Races_Data()
        {
            var races = explorer.GetCharacterRaces();

            Assert.IsTrue(races.Count() == 12);
            Assert.IsTrue(races.Any(r => r.Name == "Human" || r.Name == "Night Elf"));
        }

        [TestMethod]
        public void Get_Character_Classes_Data()
        {
            var classes = explorer.GetCharacterClasses();

            Assert.IsTrue(classes.Count() == 10);
            Assert.IsTrue(classes.Any(r => r.Name == "Warrior" || r.Name == "Death Knight"));
        }

        [TestMethod]
        public void Get_Guild_Rewards_Data()
        {
            var rewards = explorer.GetGuildRewards();
            Assert.IsTrue(rewards.Count() == 42);
            Assert.IsTrue(rewards.Any(r => r.Achievement != null));
        }


        [TestMethod]
        public void Get_Guild_Perks_Data()
        {
            var perks = explorer.GetGuildPerks();
            Assert.IsTrue(perks.Count() == 24);
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
        public void Get_Character_From_Json_String()
        {
            var briandek = explorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetEverything);
            var briandekFromJsonString = JsonUtility.FromJSONString<Character>(TestStrings.TestCharacter);
            Assert.AreEqual(0, briandek.CompareTo(briandekFromJsonString));

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLocaleException))]
        public void Set_Invalid_Locale_To_US_Region()
        {
            explorer.SetLocale(Locale.fr_FR);
        }

        [TestMethod]
        public void Get_Invalid_Character_From_Skullcrusher()
        {
            var character = explorer.GetCharacter("skullcrusher", "talasix");
            var error = explorer.ErrorInfo;

            Assert.IsNull(character);
            Assert.IsNotNull(error);
        }

        [TestMethod]
        public void Get_Invalid_Data_From_CN_Region_Throws_Exception()
        {
            var CNexplorer = new WowExplorer(Region.CN, Locale.zh_CN);

            var characterClasses = CNexplorer.GetCharacterClasses();
            var error = CNexplorer.ErrorInfo;

            Assert.IsNull(characterClasses);
            Assert.IsNotNull(error);
        }
    }

}
