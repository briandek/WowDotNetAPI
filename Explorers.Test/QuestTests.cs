using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class QuestTests
    {
        private static WowExplorer explorer;
        private static string APIKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US, APIKey);
        }

        [TestMethod]
        public void Get_Quest_Data()
        {
            var questData = explorer.GetQuestData(13146);
            Assert.IsNotNull(questData);
        }
    }
}
