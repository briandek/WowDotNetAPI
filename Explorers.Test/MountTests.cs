using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class MountTests
    {
        private static WowExplorer explorer;
        private static string APIKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US, APIKey);
        }

        [TestMethod]
        public void Get_Mount_List()
        {
            var mounts = explorer.GetMounts();
            Assert.IsTrue(mounts.Any());
        }
    }
}
