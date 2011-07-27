using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Test;
using System.Collections;
using WowDotNetAPI.Models;
using WowDotNetAPI.Utilities;
using System.IO;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void Get_Character_Races_Data()
        {
            IEnumerable<CharacterRaceInfo> races = TestUtil.WowExplorer.GetCharacterRaces();

            Assert.IsTrue(races.Count() == 12);
            Assert.IsTrue(races.Any(r => r.Name == "Human" || r.Name == "Night Elf"));
        }

        [TestMethod]
        public void Get_Character_Classes_Data()
        {
            IEnumerable<CharacterClassInfo> classes = TestUtil.WowExplorer.GetCharacterClasses();

            Assert.IsTrue(classes.Count() == 10);
            Assert.IsTrue(classes.Any(r => r.Name == "Warrior" || r.Name == "Death Knight"));
        }

        [TestMethod]
        public void Get_Guild_Rewards_Data()
        {
            IEnumerable<GuildRewardInfo> rewards = TestUtil.WowExplorer.GetGuildRewards();
            Assert.IsTrue(rewards.Count() == 42);
            Assert.IsTrue(rewards.Any(r => r.Achievement != null));
        }


        [TestMethod]
        public void Get_Guild_Perks_Data()
        {
            IEnumerable<GuildPerkInfo> perks = TestUtil.WowExplorer.GetGuildPerks();
            Assert.IsTrue(perks.Count() == 24);
            Assert.IsTrue(perks.Any(r => r.Spell != null));
        }

        //Update the file path to the Data folder in the Explorers.Test project
        [TestMethod]
        public void Get_Realms_From_Json_File()
        {
            IEnumerable<Realm> realms1 = TestUtil.WowExplorer.GetRealms();
            IEnumerable<Realm> realms2 = 
                JsonUtility.FromJSONStream<RealmsData>(File.OpenText(@"C:\Documents and Settings\Aio\My Documents\Visual Studio 2010\Projects\WowDotNetAPI\WowDotNetAPI\Explorers.Test\Data\jsonRealmsFile.txt")).Realms;

            IEnumerable<Realm> realms3 = realms1.Intersect(realms2);
            Assert.AreEqual(0, realms3.Count());

        }


        //Update the file path to the Data folder in the Explorers.Test project
        [TestMethod]
        public void Get_Character_From_Json_File()
        {
            Character briandek = TestUtil.WowExplorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetEverything);
            Character briandekFromJsonFile = 
                JsonUtility.FromJSONStream<Character>(File.OpenText(@"C:\Documents and Settings\Aio\My Documents\Visual Studio 2010\Projects\WowDotNetAPI\WowDotNetAPI\Explorers.Test\Data\jsonCharacterFile.txt"));

            Assert.AreEqual(0, briandek.CompareTo(briandekFromJsonFile));

        }
    }
}
