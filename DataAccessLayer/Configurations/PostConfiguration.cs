﻿// <copyright file="PostConfiguration.cs" company="Гылыба Л.Д.">
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
            _ = builder.HasKey(post => post.Id);
            _ = builder.Property(post => post.Name).IsRequired();
            _ = builder.Property(post => post.Salary).IsRequired();
           // _ = builder.HasMany(post => post.Employees).WithOne(employee => employee.Post).IsRequired(false);
        }
    }
}
