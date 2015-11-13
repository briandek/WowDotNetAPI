using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    class SpellTests
    {
        private static WowExplorer explorer;
        private static string APIKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US, APIKey);
        }

        [TestMethod]
        public void Get_Spell_Data()
        {
            var spell = explorer.GetSpellData(8056);
            Assert.IsNotNull(spell);
        }
    }
}
