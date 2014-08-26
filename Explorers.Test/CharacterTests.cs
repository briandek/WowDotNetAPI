using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Models;

namespace WowDotNetAPI.Test
{
    [TestClass]
    public class CharacterTests
    {
        private static WowExplorer explorer;
        private static string APIKey = "kpvwrqw2abwjh8crhsvsx7p4cbhxpmtk";

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US, APIKey);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher()
        {

            var briandek = explorer.GetCharacter("skullcrusher", "briandek");

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression); 

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(90, briandek.Level);
            Assert.AreEqual(CharacterClass.WARRIOR, briandek.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithGuild()
        {

            var briandek = explorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetGuild);

            Assert.IsNotNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(CharacterClass.WARRIOR, briandek.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithStats()
        {

            var briandek = explorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetStats);

            Assert.IsNull(briandek.Guild);
            Assert.IsNotNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(CharacterClass.WARRIOR, briandek.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithTalents()
        {

            var briandek = explorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetTalents);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNotNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(CharacterClass.WARRIOR, briandek.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Gender);
        }

		[TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithItems()
        {

            var briandek = explorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetItems);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNotNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(CharacterClass.WARRIOR, briandek.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Gender);

			Assert.AreEqual(briandek.Items.Finger2.TooltipParams.ItemUpgrade.Current, 0);
			Assert.AreEqual(briandek.Items.Finger2.TooltipParams.ItemUpgrade.Total, 4);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithReputations()
        {

            var briandek = explorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetReputation);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNotNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(CharacterClass.WARRIOR, briandek.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithTitles()
        {

            var briandek = explorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetTitles);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNotNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(CharacterClass.WARRIOR, briandek.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithProfessions()
        {

            var briandek = explorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetProfessions);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNotNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(CharacterClass.WARRIOR, briandek.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithAppearance()
        {

            var briandek = explorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetAppearance);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNotNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(CharacterClass.WARRIOR, briandek.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithPetSlots()
        {

            var briandek = explorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetPetSlots);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNotNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(CharacterClass.WARRIOR, briandek.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Gender);
            Assert.IsTrue(briandek.PetSlots.Count() > 0);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithMounts()
        {

            var briandek = explorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetMounts);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNotNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(CharacterClass.WARRIOR, briandek.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Gender);
            Assert.IsTrue(briandek.Mounts.NumCollected > 1);
            Assert.IsTrue(briandek.Mounts.NumNotCollected > 1);
        }

        [TestMethod]
        public void Get_Simple_Character_Shirokuma_From_Skullcrusher_WithHunterPets()
        {

            var shirokuma = explorer.GetCharacter("skullcrusher", "shirokuma", CharacterOptions.GetHunterPets);

            Assert.IsNull(shirokuma.Guild);
            Assert.IsNull(shirokuma.Stats);
            Assert.IsNull(shirokuma.Talents);
            Assert.IsNull(shirokuma.Items);
            Assert.IsNull(shirokuma.Reputation);
            Assert.IsNull(shirokuma.Titles);
            Assert.IsNull(shirokuma.Professions);
            Assert.IsNull(shirokuma.Appearance);
            Assert.IsNull(shirokuma.PetSlots);
            Assert.IsNull(shirokuma.Mounts);
            Assert.IsNotNull(shirokuma.HunterPets);
            Assert.IsNull(shirokuma.Pets);
            Assert.IsNull(shirokuma.Achievements);
            Assert.IsNull(shirokuma.Progression);

            Assert.IsTrue(shirokuma.Name.Equals("shirokuma", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(CharacterClass.HUNTER, shirokuma.@Class);
            Assert.AreEqual(CharacterRace.DWARF, shirokuma.Race);
            Assert.AreEqual(CharacterGender.MALE, shirokuma.Gender);
            Assert.IsTrue(shirokuma.HunterPets.Count() > 1);
        }

        [TestMethod]
        public void Get_Simple_Character_Lukenukem_From_Illidan_WithPets()
        {

            var lukenukem = explorer.GetCharacter("illidan", "lukenukem", CharacterOptions.GetPets);

            Assert.IsNull(lukenukem.Guild);
            Assert.IsNull(lukenukem.Stats);
            Assert.IsNull(lukenukem.Talents);
            Assert.IsNull(lukenukem.Items);
            Assert.IsNull(lukenukem.Reputation);
            Assert.IsNull(lukenukem.Titles);
            Assert.IsNull(lukenukem.Professions);
            Assert.IsNull(lukenukem.Appearance);
            Assert.IsNull(lukenukem.PetSlots);
            Assert.IsNull(lukenukem.Mounts);
            Assert.IsNotNull(lukenukem.Pets);
            Assert.IsNull(lukenukem.Achievements);
            Assert.IsNull(lukenukem.Progression);

            Assert.IsTrue(lukenukem.Name.Equals("lukenukem", StringComparison.InvariantCultureIgnoreCase));
            Assert.IsTrue(lukenukem.Pets.NumNotCollected > 0);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithAchievements()
        {

            var briandek = explorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetAchievements);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNotNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(CharacterClass.WARRIOR, briandek.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Gender);
        }

        [TestMethod]
        public void Get_Simple_Character_Briandek_From_Skullcrusher_WithProgression()
        {

            var briandek = explorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetProgression);

            Assert.IsNull(briandek.Guild);
            Assert.IsNull(briandek.Stats);
            Assert.IsNull(briandek.Talents);
            Assert.IsNull(briandek.Items);
            Assert.IsNull(briandek.Reputation);
            Assert.IsNull(briandek.Titles);
            Assert.IsNull(briandek.Professions);
            Assert.IsNull(briandek.Appearance);
            Assert.IsNull(briandek.PetSlots);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNotNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(CharacterClass.WARRIOR, briandek.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Gender);
        }

        [TestMethod]
        public void Get_Complex_Character_Briandek_From_Skullcrusher()
        {
            var briandek = explorer.GetCharacter("skullcrusher", "briandek", CharacterOptions.GetEverything);

            Assert.IsNotNull(briandek.Guild);
            Assert.IsNotNull(briandek.Stats);
            Assert.IsNotNull(briandek.Talents);
            Assert.IsNotNull(briandek.Items);
            Assert.IsNotNull(briandek.Reputation);
            Assert.IsNotNull(briandek.Titles);
            Assert.IsNotNull(briandek.Professions);
            Assert.IsNotNull(briandek.Appearance);
            Assert.IsNotNull(briandek.PetSlots);
            Assert.IsNotNull(briandek.Mounts);
            Assert.IsNotNull(briandek.Pets);
            Assert.IsNotNull(briandek.Achievements);
            Assert.IsNotNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));

            Assert.AreEqual(CharacterClass.WARRIOR, briandek.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Gender);

            // TODO: glyphs changed in 5.0.4 change test accordingly
            //Assert.IsTrue(briandek.Talents.Where(t => t.Selected).FirstOrDefault().Name.Equals("protection", StringComparison.InvariantCultureIgnoreCase));
            //Assert.IsTrue(briandek.Talents.ElementAt(1).Glyphs.Prime.ElementAt(0).Name.Equals("Glyph of Revenge", StringComparison.InvariantCultureIgnoreCase));

            Assert.AreEqual(0, briandek.Appearance.HairVariation);            
            Assert.IsTrue(briandek.Mounts.NumCollected > 1);
        }


        [TestMethod]
        public void Get_Complex_Character_Talasi_From_Skullcrusher()
        {
            var talasi = explorer.GetCharacter("skullcrusher", "talasi", CharacterOptions.GetEverything);

            Assert.IsNotNull(talasi.Guild);
            Assert.IsNotNull(talasi.Stats);
            Assert.IsNotNull(talasi.Talents);
            Assert.IsNotNull(talasi.Items);
            Assert.IsNotNull(talasi.Reputation);
            Assert.IsNotNull(talasi.Titles);
            Assert.IsNotNull(talasi.Professions);
            Assert.IsNotNull(talasi.Appearance);
            Assert.IsNotNull(talasi.PetSlots);
            Assert.IsNotNull(talasi.HunterPets);
            Assert.IsNotNull(talasi.Mounts);
            Assert.IsNotNull(talasi.Pets);
            Assert.IsNotNull(talasi.Achievements);
            Assert.IsNotNull(talasi.Progression);

            Assert.IsTrue(talasi.HunterPets.Any());
            Assert.IsTrue(talasi.Name.Equals("talasi", StringComparison.InvariantCultureIgnoreCase));

            Assert.AreEqual(CharacterClass.HUNTER, talasi.@Class);
            Assert.AreEqual(CharacterRace.NIGHT_ELF, talasi.Race);
            Assert.AreEqual(CharacterGender.MALE, talasi.Gender);

            Assert.IsTrue(talasi.Mounts.NumCollected > 1);
        }
       
    }
}
