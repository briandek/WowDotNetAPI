using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Explorers.Interfaces;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class TestUtil
    {
        public static IRealmExplorer rE;
        public static IGuildExplorer gE;

        [AssemblyInitialize]
        public static void GlobalStartup(TestContext testContext)
        {
            rE = new RealmExplorer();

            gE = new GuildExplorer();
            gE.GetGuild("skullcrusher", "immortality", true, true);
        }
    }
}
