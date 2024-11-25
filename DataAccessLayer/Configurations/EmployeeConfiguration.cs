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
            _ = builder.HasKey(employee => employee.ID);
            _ = builder.Property(employee => employee.FirstName).HasMaxLength(50).IsRequired();
            _ = builder.Property(employee => employee.LastName).HasMaxLength(50).IsRequired();
            _ = builder.Property(employee => employee.PatronicName).HasMaxLength(50).IsRequired();
            _ = builder.Property(employee => employee.DateBirth).HasMaxLength(50).IsRequired();
            _ = builder.Property(employee => employee.Gender).IsRequired();
            _ = builder.HasOne(employee => employee.Post).WithMany(post => post.Employees).IsRequired(false);
            _ = builder.HasMany(employee => employee.Kids).WithMany(kid => kid.Employees);
        }
    }
}
