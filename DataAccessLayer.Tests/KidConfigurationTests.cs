// <copyright file="KidConfigurationTests.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DataAccessLayer.Tests
{
    using DemoSc;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для <see cref="DataAccessLayer.Configurations.KidConfiguration"/>.
    /// </summary>
    [TestFixture]
    internal sealed class KidConfigurationTests : BaseConfigurationTests
    {
        [TearDown]
        public void TearDown()
        {
            this.DataContext.ChangeTracker.Clear();
        }

        [Test]
        public void AddEntityToDatabase_Success()
        {
            // arrange
            var name = new Name("Толстой", "Лев", "Николаевич");
            var kidName = new Name("Бипкин", "Анатолий", "Васильевич");
            var post = new Post("Тест", 1010010);
            var employee = new Employee(name, new DateOnly(1977, 09, 08), Gender.Male, post);
            var kid = new Kid(kidName, new DateOnly(2002, 09, 08), Gender.Male, employee);

            // act
            _ = this.DataContext.Add(kid);
            _ = this.DataContext.SaveChanges(); // <-- если что-то плохо, то тут БУМ!
            this.DataContext.ChangeTracker.Clear();

            // assert
            var result = this.DataContext.Find<Kid>(kid.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.FullName, Is.EqualTo(kid.FullName));
        }
    }
}
