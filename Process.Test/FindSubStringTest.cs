using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Process.Test
{
    [TestClass]
    public class FindSubStringTest
    {
        [TestMethod]
        public void When_Sperated_Word_It_Can_Be_Found()
        {
            //Case
            var s1 = "Uğur Dağaşan Dağaşan Uğur ";
            var s2 = "Dağaşan";

            //When
            var result = Process.FindSubString.Find(s1, s2);

            //Then
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void When_Combined_It_Can_Be_Found()
        {
            //Case
            var s1 = "Uğur DağaşanDağaşanDağaşanDağaşan";
            var s2 = "Dağaşan";

            //When
            var result = Process.FindSubString.Find(s1, s2);

            //Then
            Assert.AreEqual(result, 4);
        }
        [TestMethod]
        public void When_It_Can_Be_None_Case_Sensitive()
        {
            //Case
            var s1 = "Uğur DAĞAŞANdağaşan";
            var s2 = "Dağaşan";

            //When
            var result = Process.FindSubString.Find(s1, s2);

            //Then
            Assert.AreEqual(result, 2);
        }

    }
}