using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class AchievementTests
    {
        private static WowExplorer Explorer;
        private static string APIKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            Explorer = new WowExplorer(Region.US, Locale.en_US, APIKey);
        }

        [TestMethod]
        public void Get_Achievements_List()
        {
            var achievements = Explorer.GetAchievements();
            Assert.IsTrue(achievements != null && achievements.Count() > 0);
        }

        [TestMethod]
        public void Get_Achievement_Details()
        {
            var achievement = Explorer.GetAchievement(2144);
            Assert.IsNotNull(achievement);
        }

        [TestMethod]
        public void Get_Guild_Achievements_List()
        {
            var achievements = Explorer.GetGuildAchievements();
            Assert.IsTrue(achievements != null && achievements.Count() > 0);
        }
    }
}
