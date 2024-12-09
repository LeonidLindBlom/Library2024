// <copyright file="EmployeeRepository.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace Repository
{
    using System;
    using System.Linq;
    using DataAccessLayer;
    using DemoSc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Репозиторий для класса <see cref="DemoSc.Employee"/>.
    /// </summary>
    public sealed class EmployeeRepository : BaseRepository<Employee>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="EmployeeRepository"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// В случае если <paramref title="dataContext"/> – <see langword="null"/>.
        /// </exception>
        public EmployeeRepository(DataContext dataContext)
        : base(dataContext)
        {
        }

        /// <summary>
        /// Получает всех работников.
        /// </summary>
        /// <returns>Работники.</returns>
        public override IQueryable<Employee> GetAll() => this.DataContext.Employees.Include(employee => employee.Post);

        /// <summary>
        /// Найти идентификатор работнка по его фамилии.
        /// </summary>
        /// <param name="familyName">Фамилия работнка.</param>
        /// <returns>Идентификатор.</returns>
        public Guid? GetId(string familyName)
        {
            return this.Find(employee => employee.FullName.FamilyName == familyName)?.Id;
        }

        /// <summary>
        /// Получает список детей по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор работнка.</param>
        /// <returns>Список детей.</returns>
        public ISet<Kid>? GetKids(Guid id) => this.Find(employee => employee.Id == id)?.Kids;
    }
}
