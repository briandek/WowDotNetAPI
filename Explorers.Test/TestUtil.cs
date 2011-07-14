using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Explorers.Interfaces;
using WowDotNetAPI.Explorers.Models;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class TestUtil
    {
        public static IRealmExplorer rE;
        public static IGuildExplorer gE;

        public static IEnumerable<Realm> realms;

        public static Guild immortalityGuild;

        [AssemblyInitialize]
        public static void GlobalStartup(TestContext testContext)
        {
            rE = new RealmExplorer();
            gE = new GuildExplorer();

            realms = rE.GetRealms("us");
            TestUtil.immortalityGuild = gE.GetGuild("skullcrusher", "immortality", true, true);
        }
    }
}
