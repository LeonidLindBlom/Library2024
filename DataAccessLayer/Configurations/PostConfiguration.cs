// <copyright file="PostConfiguration.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using DemoSc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Post"/>) в таблицу БД.
    /// </summary>
    internal sealed class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            throw new NotImplementedException();
        }
    }
}
