// <copyright file="PostRepository.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using DataAccessLayer;
    using DemoSc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Репозиторий для класса <see cref="Domain.Shelf"/>.
    /// </summary>
    public sealed class PostRepository : BaseRepository<Post>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PostfRepository"/>.
        /// </summary>
        /// <param name="dataContext"> Контекст доступа к данным.</param>
        /// <exception cref="ArgumentNullException">
        /// В случае если <paramref name="dataContext"/> – <see langword="null"/>.
        /// </exception>
        public PostRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        /// <inheritdoc/>
        // @NOTE: IgnoreAutoIncludes()
        public override IQueryable<Post> GetAll() => this.DataContext.Posts;

        /// <summary>
        /// Показать количество работников на этой должности.
        /// </summary>
        /// <param name="id">Идентификатор должности.</param>
        /// <returns> Количество книг.</returns>
        public int? GetCountEmployees(Guid id) => this.Get(id)?.Employees.Count;

        /// <summary>
        /// Показать количество работников на этой должности.
        /// </summary>
        /// <param name="name">Название должности.</param>
        /// <returns>Количество книг.</returns>
        public int? GetCountEmployees(string name)
        {
            var id = this.GetIdByName(name);

            return id.HasValue
                ? this.GetCountEmployees(id.Value)
                : null;
        }

        /// <summary>
        /// Найти идентификатор по имени.
        /// </summary>
        /// <param name="name">Название должности.</param>
        /// <returns>Идентификатор.</returns>
        public Guid? GetIdByName(string name) => this.Find(post => post.Name == name)?.Id;
    }
}
