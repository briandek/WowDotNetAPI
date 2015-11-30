using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Explorers.Test
{
    [TestClass]
    public class PetTests
    {
        private static WowExplorer explorer;
        private static string APIKey = TestStrings.APIKey;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US, APIKey);
        }

        [TestMethod]
        public void Get_Pet_List()
        {
            var pets = explorer.GetPets();
            Assert.IsTrue(pets.Any());
        }

        [TestMethod]
        public void Get_Pet_Ability_Details()
        {
            var ability = explorer.GetPetAbilityDetails(640);
            Assert.IsNotNull(ability);
        }

        [TestMethod]
        public void Get_Pet_Species()
        {
            var species = explorer.GetPetSpeciesDetails(258);
            Assert.IsNotNull(species);
        }

        [TestMethod]
        public void Get_Pet_Stats()
        {
            var stats = explorer.GetPetStats(258, 25, 5, 4);
            Assert.IsNotNull(stats);
        }

        [TestMethod]
        public void Get_Pet_Types()
        {
            var types = explorer.GetPetTypes();
            Assert.IsTrue(types.Any());
        }
    }
}
