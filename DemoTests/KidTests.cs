// <copyright file="KidTests.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DemoTests
{
    using DemoSc;
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]

    internal class KidTests
    {
        private static readonly Name NameValue = new ("Толстой", "Лев", "Николаевич");
        private static readonly Name NameValue1 = new ("Галлер", "Кирилл", "Николаевич");
        private static readonly Post Post = new ("Тестовое название", 10000);
        private static readonly Employee Employee = new (NameValue, new DateOnly(2002, 09, 08), Gender.Male, Post);

        [Test]
        public void Ctor_ValidDate_DoesNotThrow()
        {
            Assert.DoesNotThrow(() =>
            _ = new Kid(NameValue, new DateOnly(2002, 09, 08), Gender.Male, Employee));
        }

        [Test]
        public void Equals_ValidDataDifferentName_Success()
        {
            // Arrange
            var kid1 = new Kid(NameValue, new DateOnly(2002, 09, 08), Gender.Male, Employee);
            var kid2 = new Kid(NameValue1, new DateOnly(1973, 01, 08), Gender.Female, Employee);

            // Act & Assert
            Assert.That(kid1, Is.Not.EqualTo(kid2));
        }
    }
}
