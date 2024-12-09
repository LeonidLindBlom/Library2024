using DemoSc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Tests
{
    internal class KidRepositoryTests 
        : BaseReposytoryTests<KidRepository, Kid>
    {
        [SetUp]
        public void SetUp()
        {
            _ = this.DataContext.Database.EnsureCreated();
        }

        [TearDown]
        public void TearDown()
        {
            _ = this.DataContext.Database.EnsureDeleted();
        }

        [Test]
        public void Create_ValidData_Success()
        {
            // arrange
            var name = new Name("Толстой", "Лев", "Николаевич");
            var kidName = new Name("Бипкин", "Анатолий", "Васильевич");
            var post = new Post("Тест", 1010010);
            var employee = new Employee(name, new DateOnly(1977, 09, 08), Gender.Male, post);
            var kid = new Kid(kidName, new DateOnly(2002, 09, 08), Gender.Male, employee);

            // act
            _ = this.Repository.Create(kid);

            // assert
            var result = this.DataContext.Find<Kid>(kid.Id);

            Assert.That(result, Is.EqualTo(kid));
        }

        [Test]
        public void Delete_ValidData_Success()
        {
            // arrange
            var name = new Name("Пупкин", "Василий", "Семенович");
            Post post = new ("Тест", 10000);
            var employee = new Employee(name, new DateOnly(1977, 09, 08), Gender.Male, post);
            var kidName = new Name("Бипкин", "Анатолий", "Васильевич");
            var kid = new Kid(kidName, new DateOnly(2002, 09, 08), Gender.Male, employee);
            _ = this.DataContext.Add(kid);
            _ = this.DataContext.SaveChanges();

            // act
            _ = this.Repository.Delete(kid);

            // assert
            var result = this.DataContext.Find<Kid>(kid.Id);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetIdByName_FamilyName_Success()
        {
            // arrange
            var familyName = "Толстой";
            var name = new Name("Бипкин", "Анатолий", "Васильевич");
            var post = new Post("Тест", 1010010);
            var employee = new Employee(name, new DateOnly(1977, 09, 08), Gender.Male, post);


            var kids = new[]
            {
                new Kid(new Name(familyName, "Лев", "Николаевич"), new DateOnly(2002, 09, 08), Gender.Male, employee),
                new Kid(new Name(familyName, "Алексей", "Константинович"), new DateOnly(2002, 09, 08), Gender.Male, employee),
                new Kid(new Name(familyName, "Алексей", "Николаевич"), new DateOnly(2002, 09, 08), Gender.Male, employee),
            };

            this.DataContext.AddRange(kids);
            _ = this.DataContext.SaveChanges();
            this.DataContext.ChangeTracker.Clear();

            // act
            var result = this.Repository.GetId(familyName);

            // Act
            Assert.That(
                kids.Select(kid => kid.Id),
                Has.One.EqualTo(result),
                message: "Полученный идентификатор входит в множество идентификаторов целевых детей");
        }
    }
}
