

namespace Repository
{

    using System;
    using System.Linq;
    using DataAccessLayer;
    using DemoSc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Репозиторий для класса <see cref="DemoSc.Kid"/>.
    /// </summary>
    public sealed class KidRepository : BaseRepository<Kid>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="KidRepository"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// В случае если <paramref title="dataContext"/> – <see langword="null"/>.
        /// </exception>
        public KidRepository(DataContext dataContext)
        : base(dataContext)
        {
        }

        /// <summary>
        /// Получает всех детей.
        /// </summary>
        /// <returns>Дети.</returns>
        public override IQueryable<Kid> GetAll() => this.DataContext.Kids;

        /// <summary>
        /// Найти идентификатор ребенка по его фамилии.
        /// </summary>
        /// <param name="familyName">Фамилия ребенка.</param>
        /// <returns>Идентификатор.</returns>
        public Guid? GetId(string familyName)
        {
            return this.Find(kid => kid.FullName.FamilyName == familyName)?.Id;
        }

        /// <summary>
        /// Получает список работников по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор ребенка.</param>
        /// <returns>Список работников.</returns>
        public ISet<Employee>? GetEmployees(Guid id) => this.Find(kid => kid.Id == id)?.Employees;

    }
}
