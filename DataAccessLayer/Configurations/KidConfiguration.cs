// <copyright file="KidConfiguration.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using DemoSc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Kid"/>) в таблицу БД.
    /// </summary>
    internal sealed class KidConfiguration : IEntityTypeConfiguration<Kid>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Kid> builder)
        {
            _ = builder.HasKey(kid => kid.ID);
            _ = builder.Property(kid => kid.FirstName).HasMaxLength(50).IsRequired();
            _ = builder.Property(kid => kid.LastName).HasMaxLength(50).IsRequired();
            _ = builder.Property(kid => kid.PatronicName).HasMaxLength(50).IsRequired();
            _ = builder.Property(kid => kid.DateBirth).HasMaxLength(50).IsRequired();
            _ = builder.Property(kid => kid.Gender).IsRequired();
            _ = builder.HasMany(kid => kid.Employees).WithMany(employee => employee.Kids);
        }
    }
}
