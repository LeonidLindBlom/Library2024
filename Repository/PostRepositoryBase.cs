// <copyright file="PostRepositoryBase.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace Repository
{
    using DataAccessLayer;
    using DemoSc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class PostRepositoryBase
    {
        /// <summary>
        /// Контекст доступа к данным.
        /// </summary>
        public DataContext DataContext { get; set; }

        /// <summary>
        /// Создает должность.
        /// </summary>
        /// <param name="entity">Должность.</param>
        /// <returns>Контекст доступа к сущности Должность.</returns>
        public Post Create(Post entity) => this.DataContext.Add(entity).Entity;

        /// <summary>
        /// Удаляет должность.
        /// </summary>
        /// <param name="post">Должность.</param>
        /// <returns>Измененный контекст доступа к сущности Полка.</returns>
        public Post Delete(Post post) => this.DataContext.Remove(post).Entity;

        /// <summary>
        /// Поиск множества должностей по предикату (<paramref name="predicate"/>).
        /// </summary>
        /// <param name="predicate">Предикат, которому должна удовлетворять должность.</param>
        /// <returns>Множество (<see cref="IQueryable{Shelf}"/>) всех должностей.</returns>
        public IQueryable<Post> Filter(Expression<Func<Post, bool>> predicate) => this.GetAll().Where(predicate);

        /// <summary>
        /// Поиск должности по предикату (<paramref name="predicate"/>).
        /// </summary>
        /// <param name="predicate">Предикат, которому должна удовлетворять должность.</param>
        /// <returns>Должность или <see langword="null"/>.</returns>
        public Post? Find(Expression<Func<Post, bool>> predicate) => this.GetAll().FirstOrDefault(predicate);

        /// <summary>
        /// Получение конкретной должности по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор должности.</param>
        /// <returns>Должность.</returns>
        public Post? Get(Guid id) => this.GetAll().SingleOrDefault(entity => entity.Id == id);

        /// <summary>
        /// Получение всех должностей.
        /// </summary>
        /// <returns> Множество (<see cref="IQueryable{Post}"/>) всех должностей.</returns>
        public IQueryable<Post> GetAll() => this.DataContext.Posts.IgnoreAutoIncludes();

        /// <summary>
        /// Сохраняет контекст в БД.
        /// </summary>
        /// <returns>Количество измененных сущностей.</returns>
        public int Save() => this.DataContext.SaveChanges();

        /// <summary>
        /// Изменяет полку.
        /// </summary>
        /// <param name="post">Должность.</param>
        /// <returns>Измененный контекст доступа к сущности Должность.</returns>
        public Post Update(Post post) => this.DataContext.Update(post).Entity;
    }
}
