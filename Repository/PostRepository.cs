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
    public sealed class PostRepository : PostRepositoryBase
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PostRepository"/>.
        /// </summary>
        /// <param name="dataContext"> Контекст доступа к данным.</param>
        /// <exception cref="ArgumentNullException">
        /// В случае если <paramref name="dataContext"/> – <see langword="null"/>.
        /// </exception>
        public PostRepository(DataContext dataContext)
        {
            this.DataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }
    }
}
