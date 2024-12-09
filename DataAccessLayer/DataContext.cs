// <copyright file="DataContext.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DataAccessLayer
{
    using System.Reflection;
    using DemoSc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Контекст доступа к данным.
    /// </summary>
    public class DataContext : DbContext
    {
        private static readonly string ConnectionString = "User ID = postgres; Password=admin;Host=localhost;Port=5432;Database=Library;";

        private static readonly DbContextOptions<DataContext> Options = new DbContextOptionsBuilder<DataContext>()
            .UseNpgsql(ConnectionString)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .LogTo(System.Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Error)
            .Options;
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DataContext"/>.
        /// </summary>
        public DataContext()
            : this(Options)
        {
        }
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
        public DbSet<Employee> Employees { get; init; }

        /// <summary>
        /// Дети.
        /// </summary>
        public DbSet<Kid> Kids { get; init; }

        /// <summary>
        /// Должности.
        /// </summary>
        public DbSet<Post> Posts { get; init; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
