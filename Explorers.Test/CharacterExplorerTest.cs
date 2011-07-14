using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Explorers.Models;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class CharacterExplorerTest
    {
        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher()
        {
            CharacterExplorer cE = new CharacterExplorer();

            Character briandek = cE.GetCharacter("skullcrusher", "briandek");

            Assert.IsTrue(briandek.name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(briandek.level == 85);
            Assert.IsTrue(briandek.@class == 1);
        }

        [TestMethod]
        public void Get_Complex_Character_Briandek_From_Skullcrusher()
        {
            CharacterExplorer cE = new CharacterExplorer();

            Character briandek = cE.GetCharacter("skullcrusher", "briandek",
                true,
                true,
                true,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false);

            //iterate through stats
            //var statsList = briandek.stats;
            //foreach (KeyValuePair<string, object> stat in briandek.stats)
            //{
            //}

            Assert.IsTrue(briandek.name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(briandek.level == 85);
            Assert.IsTrue(briandek.@class == 1);

            Assert.IsTrue(briandek.talents.Where(t => t.selected).FirstOrDefault().name.Equals("protection", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(briandek.talents.ElementAt(1).glyphs.prime.ElementAt(0).name.Equals("Glyph of Revenge", StringComparison.InvariantCultureIgnoreCase));

        }
    }
}
