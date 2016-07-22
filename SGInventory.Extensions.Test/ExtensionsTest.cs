using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SGInventory.Extensions.Test
{
    [TestClass]
    public class ExtensionsTest
    {
        [TestMethod]
        public void Validate_GivenThatInputNotExceedingMaxLength_ShouldReturnTrue()
        {
            
            var maxLength = 25;
            var input = string.Empty;

            for (int i = 0; i < maxLength - 1; i++)
            {
                input = string.Concat(input, "X");
            }

            Assert.IsTrue(input.ValidateMaxLength(maxLength));



        }

        [TestMethod]
        public void Validate_GivenThatInputEqualsMaxLength_ShouldReturnTrue()
        {
           
            var maxLength = 25;
            var input = string.Empty;

            for (int i = 0; i < maxLength; i++)
            {
                input = string.Concat(input, "X");
            }

            Assert.IsTrue(input.ValidateMaxLength(maxLength));



        }

        [TestMethod]
        public void Validate_GivenThatInputExceedsMaxLength_ShouldReturnTrue()
        {
           
            var maxLength = 25;
            var input = string.Empty;

            for (int i = 0; i < maxLength + 10; i++)
            {
                input = string.Concat(input, "X");
            }

            Assert.IsFalse(input.ValidateMaxLength(maxLength));



        }
    }
}
