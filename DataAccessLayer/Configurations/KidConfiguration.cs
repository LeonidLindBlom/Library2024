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
            _ = builder.HasKey(kid => kid.Id);
            _ = builder.OwnsOne(
               author => author.FullName,
               nameBuilder =>
               {
                   _ = nameBuilder.Property(name => name.FamilyName)
                       .HasColumnName(nameof(Name.FamilyName))
                       .HasMaxLength(100)
                       .IsRequired()
                       .HasComment("Фамилия");

                   _ = nameBuilder.Property(name => name.FirstName)
                       .HasColumnName(nameof(Name.FirstName))
                       .HasMaxLength(100)
                       .IsRequired()
                       .HasComment("Имя");

                   _ = nameBuilder.Property(name => name.PatronicName)
                       .HasColumnName(nameof(Name.PatronicName))
                       .HasMaxLength(100)
                       .IsRequired()
                       .HasComment("Отчество");
               });
            _ = builder.Property(kid => kid.DateBirth).HasMaxLength(50).IsRequired();
            _ = builder.Property(kid => kid.Gender).IsRequired();
            _ = builder.HasMany(kid => kid.Employees).WithMany(employee => employee.Kids);
        }
    }
}
