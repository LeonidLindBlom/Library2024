// <copyright file="DataContext.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DataAccessLayer
{
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using DemoSc;

    /// <summary>
    /// Контекст доступа к данным.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DataContext"/> class.
        /// </summary>
        /// <param name="options">Опции настройки контекста.</param>
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        /// <summary>
        /// Работники.
        /// </summary>
        public DbSet<Employee> Employees { get; }

        /// <summary>
        /// Дети.
        /// </summary>
        public DbSet<Kid> Kids { get; }

        /// <summary>
        /// Должности.
        /// </summary>
        public DbSet<Post> Posts { get; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=1;Host=localhost;Port=5432;Database=Library;");
        }
    }
}
