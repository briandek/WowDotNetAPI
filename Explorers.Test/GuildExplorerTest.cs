using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Explorers.Interfaces;
using WowDotNetAPI.Explorers.Utilities;
using System.Net;
using System.Web.Script.Serialization;
using WowDotNetAPI.Explorers.Models;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class GuildExplorerTest
    {
        Guild immortalityGuild;

        [TestInitialize]
        public void Setup()
        {
            immortalityGuild = TestUtil.gE.Guild;
        }

        [TestMethod]
        public void Get_Simple_Guild_Immortality_From_Skullcrusher()
        {
            Assert.IsTrue(immortalityGuild.name.Equals("immortality", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(immortalityGuild.realm.Equals("skullcrusher", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(immortalityGuild.members.Any());
        }

        [TestMethod]
        public void Get_Valid_Member_From_Immortality_Guild()
        {
            Member briandek = immortalityGuild.members.Where(m => m.character.name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            Assert.IsTrue(briandek.character.name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(briandek.character.@class == 1);
            Assert.IsTrue(briandek.character.gender == 0);
            //Assert.IsTrue(briandek.character.achievementPoints == 6895); achievements via guild api is broken ._.

        }

        [TestMethod]
        public void Get_Valid_Member_From_Another_Guild()
        {
            TestUtil.gE = new GuildExplorer("Laughing Skull", "Deus Vox", true, false);
            Guild dvGuild = TestUtil.gE.Guild;

            Assert.IsTrue(dvGuild.name.Equals("deus vox", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(dvGuild.realm.Equals("laughing skull", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(dvGuild.members.Any());


            Member ohnoes = dvGuild.members.Where(m => m.character.name.Equals("ohnoes", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            Assert.IsTrue(ohnoes.character.name.Equals("ohnoes", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(ohnoes.character.@class == 4);
            Assert.IsTrue(ohnoes.character.gender == 1);
        }
    }
}
