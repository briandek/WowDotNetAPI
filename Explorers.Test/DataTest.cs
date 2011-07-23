using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Test;
using System.Collections;
using WowDotNetAPI.Models;

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



    }
}
