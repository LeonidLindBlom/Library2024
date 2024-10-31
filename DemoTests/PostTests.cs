// <copyright file="PostTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DemoTests
{
    using System;
    using System.Collections.Generic;
    using DemoSc;
    using NUnit.Framework;

    [TestFixture]
    public class PostTests
    {
        [Test]
        public void Ctor_ValidData_Success()
        {
            Assert.DoesNotThrow(() => _ = new Post("Тестовое название", 10000));
        }

        [Test]
        public void Ctor_NullData_ExpectedException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new Post(null!, 10000));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Ctor_NegativeSalary_ExpectedArgumentOutOfRangeException(int salary)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Post("Тестовое название", salary));
        }

        [Test]
        public void Equals_ValidDataDifferentName_Success()
        {
            // Arrange
            var post1 = new Post("Директор", 1000000);
            var post2 = new Post("Уборщик", 10000);

            // Act & Assert
            Assert.That(post1, Is.Not.EqualTo(post2));
        }
    }
}