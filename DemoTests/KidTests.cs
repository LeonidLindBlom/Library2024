// <copyright file="KidTests.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DemoTests
{
    using DemoSc;

    [TestFixture]

    internal class KidTests
    {
        private static readonly Employee Employee = new ("Имя", "Фамилия", "Отчество", new DateOnly(1955, 01, 01), Gender.Female, new ("Тестовое название", 10000));

        [Test]
        public void Ctor_ValidDate_DoesNotThrow()
        {
            Assert.DoesNotThrow(() =>
            _ = new Kid("Павлик", "Морозов", "Русланович", new DateOnly(2002, 09, 08), Employee, Gender.Male));
        }

        [Test]
        public void Equals_ValidDataDifferentName_Success()
        {
            // Arrange
            var kid1 = new Kid("Павлик", "Морозов", "Русланович", new DateOnly(2002, 09, 08), Employee, Gender.Male);
            var kid2 = new Kid("Дима", "Степанов", "Гениевич", new DateOnly(1973, 01, 08), Employee, Gender.Female);

            // Act & Assert
            Assert.That(kid1, Is.Not.EqualTo(kid2));
        }
    }
}
