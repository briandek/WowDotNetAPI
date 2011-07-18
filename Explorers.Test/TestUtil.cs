using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Interfaces;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Test
{
    [TestClass]
    public class TestUtil
    {
        public static IExplorer WowExplorer;

        public static IEnumerable<Realm> realms;

        public static Guild immortalityGuild;

        [AssemblyInitialize]
        public static void GlobalStartup(TestContext testContext)
        {
            WowExplorer = new WowExplorer("us");

            realms = WowExplorer.GetRealms();
            TestUtil.immortalityGuild = WowExplorer.GetGuild("skullcrusher", "immortality", true, true);
        }
    }
}
