// <copyright file="EmployeeRepositoryTests.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace Repository.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using DemoSc;
    using NUnit.Framework;

    internal sealed class EmployeeRepositoryTests 
        : BaseReposytoryTests<EmployeeRepository, Employee>
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
            var name = new Name("Пупкин", "Василий", "Семенович");
            var post = new Post("Тестовое название", 10000);
            var employee = new Employee(name, new DateOnly(2002, 09, 08), Gender.Male, post);
            // act
            _ = this.Repository.Create(employee);

            // assert
            var result = this.DataContext.Find<Employee>(employee.Id);

            Assert.That(result, Is.EqualTo(employee));
        }

        [Test]
        public void Update_ValidData_Success()
        {
            // arrange
            var name = new Name("Пупкин", "Василий", "Семенович");
            Post post = new ("Тестовое название", 10000);
            var employee = new Employee(name, new DateOnly(2002, 09, 08), Gender.Male, post);
            _ = this.DataContext.Add(employee);
            _ = this.DataContext.SaveChanges();

            // act
            employee.DateBirth = new DateOnly(1828, 09, 28);
            _ = this.Repository.Update(employee);

            // assert
            var result = this.DataContext.Find<Employee>(employee.Id)?.DateBirth;

            Assert.That(result, Is.EqualTo(employee.DateBirth));
        }

        [Test]
        public void Delete_ValidData_Success()
        {
            // arrange
            var name = new Name("Пупкин", "Василий", "Семенович");
            Post post = new ("Тест", 10000);
            var employee = new Employee(name, new DateOnly(2002, 09, 08), Gender.Male, post);
            _ = this.DataContext.Add(employee);
            _ = this.DataContext.SaveChanges();

            // act
            _ = this.Repository.Delete(employee);

            // assert
            var result = this.DataContext.Find<Employee>(employee.Id);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetIdByName_FamilyName_Success()
        {
            // arrange
            var familyName = "Толстой";
            Post post = new ("Тестовое название", 10000);

            var employees = new[]
            {
                new Employee(new Name(familyName, "Лев", "Николаевич"), new DateOnly(2002, 09, 08), Gender.Male, post),
                new Employee(new Name(familyName, "Алексей", "Константинович"), new DateOnly(2002, 09, 08), Gender.Male, post),
                new Employee(new Name(familyName, "Алексей", "Николаевич"), new DateOnly(2002, 09, 08), Gender.Male, post),
            };

            this.DataContext.AddRange(employees);
            _ = this.DataContext.SaveChanges();
            this.DataContext.ChangeTracker.Clear();

            // act
            var result = this.Repository.GetId(familyName);

            // Act
            Assert.That(
                employees.Select(employee => employee.Id),
                Has.One.EqualTo(result),
                message: "Полученный идентификатор входит в множество идентификаторов целевых работников");
        }

        [Test]
        public void GetKidsById_ValidData_Success()
        {
            var name = new Name("Толстой", "Лев", "Николаевич");
            var post = new Post("Тест", 1010010);
            var employee = new Employee(name, new DateOnly(1977, 09, 08), Gender.Male, post);
            var kid = new Kid(new Name("Иванов", "Степан", "Анатольевич"), new DateOnly(2024, 09, 08), Gender.Male, employee);
            var kids = new HashSet<Kid>();
            //_ = kids.Add(kid);

            _ = this.DataContext.Add(employee);
            _ = this.DataContext.SaveChanges();
            this.DataContext.ChangeTracker.Clear();

            // act
            var result = this.Repository.GetKids(employee.Id);

            // assert
            Assert.That(result, Is.EqualTo(kids));
        }
    }
}
