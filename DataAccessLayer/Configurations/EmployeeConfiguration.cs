// <copyright file="EmployeeConfiguration.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using DemoSc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Employee"/>) в таблицу БД.
    /// </summary>
    internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            _ = builder.HasKey(employee => employee.Id);
            _ = builder.OwnsOne(
               employee => employee.FullName,
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
            _ = builder.Property(employee => employee.DateBirth).HasMaxLength(50).IsRequired();
            _ = builder.Property(employee => employee.Gender).IsRequired();
            _ = builder.HasOne(employee => employee.Post).WithMany(post => post.Employees).IsRequired();
            _ = builder.HasMany(employee => employee.Kids).WithMany(kid => kid.Employees);
        }
    }
}
