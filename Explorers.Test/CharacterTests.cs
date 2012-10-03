using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WowDotNetAPI.Models;
using WowDotNetAPI.Exceptions;

namespace WowDotNetAPI.Test
{
    [TestClass]
    public class CharacterTests
    {
        private static WowExplorer explorer;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            explorer = new WowExplorer(Region.US, Locale.en_US);
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
            Assert.IsNull(briandek.Companions);
            Assert.IsNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNull(briandek.Achievements);
            Assert.IsNull(briandek.Progression); 

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));
            Assert.AreEqual(85, briandek.Level);
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
            Assert.IsNotNull(briandek.Companions);
            Assert.IsNotNull(briandek.Mounts);
            Assert.IsNull(briandek.Pets);
            Assert.IsNotNull(briandek.Achievements);
            Assert.IsNotNull(briandek.Progression);

            Assert.IsTrue(briandek.Name.Equals("briandek", StringComparison.InvariantCultureIgnoreCase));

            Assert.AreEqual(85, briandek.Level);
            Assert.AreEqual(CharacterClass.WARRIOR, briandek.@Class);
            Assert.AreEqual(CharacterRace.HUMAN, briandek.Race);
            Assert.AreEqual(CharacterGender.MALE, briandek.Gender);

            // TODO: glyphs changed in 5.0.4 change test accordingly
            //Assert.IsTrue(briandek.Talents.Where(t => t.Selected).FirstOrDefault().Name.Equals("protection", StringComparison.InvariantCultureIgnoreCase));
            //Assert.IsTrue(briandek.Talents.ElementAt(1).Glyphs.Prime.ElementAt(0).Name.Equals("Glyph of Revenge", StringComparison.InvariantCultureIgnoreCase));

            Assert.IsTrue(briandek.Appearance.HairVariation == 13);
            Assert.IsTrue(briandek.Companions.ElementAt(1) == 32298);
            Assert.IsTrue(briandek.Items.AverageItemLevelEquipped == 364);

            Assert.IsTrue(briandek.Mounts.Count() == 11);
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
            Assert.IsNotNull(talasi.Companions);
            Assert.IsNotNull(talasi.Mounts);
            Assert.IsNotNull(talasi.Pets);
            Assert.IsNotNull(talasi.Achievements);
            Assert.IsNotNull(talasi.Progression);

            Assert.IsTrue(talasi.Pets.Any());
            Assert.IsTrue(talasi.Name.Equals("talasi", StringComparison.InvariantCultureIgnoreCase));

            Assert.AreEqual(85, talasi.Level);
            Assert.AreEqual(CharacterClass.HUNTER, talasi.@Class);
            Assert.AreEqual(CharacterRace.NIGHT_ELF, talasi.Race);
            Assert.AreEqual(CharacterGender.MALE, talasi.Gender);

            Assert.AreEqual(11, talasi.Mounts.Count());
        }
       
    }
}
