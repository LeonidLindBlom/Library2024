// <copyright file="EmployeeTests.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DemoTests
{
    using DemoSc;

    [TestFixture]
    internal class EmployeeTests
    {
        private static readonly Post Post = new ("Тестовое название", 10000);

        [Test]
        public void Ctor_ValidDate_DoesNotThrow()
        {
            Assert.DoesNotThrow(() =>
            _ = new Employee("Толстой", "Лев", "Акакиевич", new DateOnly(2002, 09, 08), Gender.Male, Post));
        }

        [Test]
        public void Equals_ValidDataDifferentName_Success()
        {
            // Arrange
            var employee1 = new Employee("Толстой", "Лев", "Николаевич", new DateOnly(1828, 09, 28), Gender.Male, Post);
            var employee2 = new Employee("Пушкин", "Александр", "Сергеевич", new DateOnly(1799, 06, 06), Gender.Male, Post);

            // Act & Assert
            Assert.That(employee1, Is.Not.EqualTo(employee2));
        }
    }
}