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
        private static readonly ISet<Employee> Employees = new HashSet<Employee>() { Employee };

        [Test]
        public void Ctor_ValidDate_DoesNotThrow()
        {
            Assert.DoesNotThrow(() =>
            _ = new Kid(NameValue, new DateOnly(2002, 09, 08), Employees, Gender.Male));
        }

        [Test]
        public void Equals_ValidDataDifferentName_Success()
        {
            // Arrange
            var kid1 = new Kid(NameValue, new DateOnly(2002, 09, 08), Employees, Gender.Male);
            var kid2 = new Kid(NameValue, new DateOnly(1973, 01, 08), Employees, Gender.Female);

            // Act & Assert
            Assert.That(kid1, Is.Not.EqualTo(kid2));
        }
    }
}
