using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Process.Test
{
    /// <summary>
    /// FindSubStringTest
    /// </summary>
    [TestClass]
    public class FindSubStringTest
    {
        /// <summary>
        /// Whens the sperated word it can be found.
        /// </summary>
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

        /// <summary>
        /// Whens the combined it can be found.
        /// </summary>
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
        /// <summary>
        /// Whens it can be none case sensitive.
        /// </summary>
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