using NUnit.Framework;
using PF2E;
using System;
using System.Collections.Generic;
using System.Text;

namespace PF2ETests
{
    [TestFixture()]
    public class PF2eCoreUtilsTests
    {
        [Test()]
        public void GetClassesOfIBackgroundReturnsAccurateList()
        {
            var expected = new List<string> // only alphabetical lists will pass
            { "Emancipated",
                "Scholar"
            };
            var actual = PF2eCoreUtils.GetListOfBackgrounds();
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void GetClassesOfIAncestryReturnsAccurateList()
        {
            var expected = new List<string> // only alphabetical lists will pass
            {
                "Dwarf",
                "Elf",
                "Gnome",
                "Goblin",
                "HalfElf",
                "Halfling",
                "HalfOrc",
                "Hobgoblin",
                "Human",
                "Leshy"
            };
            var actual = PF2eCoreUtils.GetListOfAncestries();
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void GetClassesOfIPcClassReturnsAccurateList()
        {
            var expected = new List<string> // only alphabetical lists will pass
            {
                "Rogue"
            };
            var actual = PF2eCoreUtils.GetListOfClasses();
            Assert.AreEqual(expected, actual);
        }
    }
}