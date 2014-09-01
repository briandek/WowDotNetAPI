using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Utilities;
using System.Net;
using System.Web.Script.Serialization;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class ChallengesTests
    {
        private static WowExplorer explorer;
        private static Challenges challenges;
        private static string APIKey = "";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US, APIKey);            
        }

        [TestMethod]
        public void Get_Challenges_From_Skullcrusher()
        {
            challenges = explorer.GetChallenges("skullcrusher");
            Assert.IsTrue(challenges.Challenge.Count() > 0);            
            Assert.IsTrue(challenges.Challenge.First().Groups.Count() > 0);
            Assert.IsTrue(challenges.Challenge.First().Map.Name != "");
        }
    }
}
