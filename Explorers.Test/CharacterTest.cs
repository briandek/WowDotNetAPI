using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Test
{
    [TestClass]
    public class CharacterTest
    {
        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher()
        {
            Character briandek = TestUtil.WowExplorer.GetCharacter("skullcrusher", "briandek");

            Assert.IsTrue(briandek.name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(briandek.level == 85);
            Assert.IsTrue(briandek.@class == 1);
        }

        [TestMethod]
        public void Get_Complex_Character_Briandek_From_Skullcrusher()
        {

            Character briandek = TestUtil.WowExplorer.GetCharacter("skullcrusher", "briandek",
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true);

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

            Assert.IsTrue(briandek.appearance.hairVariation == 13);
            Assert.IsTrue(briandek.companions.ElementAt(1) == 32298);
            Assert.IsTrue(briandek.items.averageItemLevelEquipped == 364);

            Assert.IsTrue(briandek.mounts.Count() == 11);
        }
    }
}
