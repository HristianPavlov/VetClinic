using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VetClinic.Test.VetClinic.Data.Models
{
    [TestClass]
    public class Person
    {
        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_FirstName_Is_Null()
        {
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_FirstName_Is_Empty()
        {
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_LastName_Is_Null()
        {
        }

        [TestMethod]
        public void Constructor_Should_Throw_ArgumentNullException_When_LastName_Is_Empty()
        {
        }
    }
}
