// <copyright file="PostRepositoryTests.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace Repository.Tests
{
    using DemoSc;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для <see cref="ShelfRepository"/>.
    /// </summary>
    [TestFixture]
    internal sealed class PostRepositoryTests
        : BaseReposytoryTests<PostRepository, Post>
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
            var post = new Post("Уборщик", 10101001);

            // act
            _ = this.Repository.Create(post);

            // arrange
            var result = this.DataContext.Find<Post>(post.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo(post.Name));
        }

        [Test]
        public void Get_ValidData_Success()
        {
            // arrange
            var shelf = new Post("Уборщик", 10101010);

            this.DataContext.Add(shelf);
            this.DataContext.SaveChanges();

            // act
            var result = this.Repository.Get(shelf.Id);

            // assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo(shelf.Name));
        }

        [Test]
        public void Update_ValidData_Success()
        {
            // arrange
            var newName = "Новое имя";
            var setSalary = 8994878438734;

            var post = new Post("Тестовая", 1010101001);

            this.DataContext.Add(post);
            this.DataContext.SaveChanges();

            // act
            post.Name = newName;
            post.Salary = setSalary;
            var result = this.Repository.Update(post);

            // assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo(newName));
        }

        [Test]
        public void Delete_ValidData_Success()
        {
            // arrange
            var post = new Post("Уборщик", 10101010);

            this.DataContext.Add(post);
            this.DataContext.SaveChanges();

            // act
            _ = this.Repository.Delete(post);

            // arrange
            var result = this.DataContext.Find<Post>(post.Id);

            Assert.That(result, Is.Null);
        }
    }
}
