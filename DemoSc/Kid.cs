// <copyright file="Kid.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DemoSc
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Класс ребенок.
    /// </summary>
    public sealed class Kid : Human<Kid>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Kid"/>.
        /// </summary>
        /// <param name="fullName"> Имя.</param>
        /// <param name="dateBirth">Дата рорждения.</param>
        /// <param name="employees">Работник.</param>
        /// <param name="gender">Пол.</param>
        /// <exception cref="ArgumentNullException">
        /// Если Полное имя <see langword="null"/>.
        /// </exception>
        public Kid(Name fullName, DateOnly dateBirth, ISet<Employee> employees, Gender gender)
            : base(fullName, dateBirth, gender)
        {
            this.Employees = employees;
            foreach (var employee in employees)
            {
                employee.AddKid(this);
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Kid"/>.
        /// </summary>
        /// <param name="fullName"> Имя.</param>
        /// <param name="dateBirth">Дата рорждения.</param>
        /// <param name="employees">Работник.</param>
        /// <param name="gender">Пол.</param>
        /// <exception cref="ArgumentNullException">Если название книги или код <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"> Если количество страниц меньше или равно нулю.</exception>
        /// <exception cref="ArgumentOutOfRangeException"> Если полка <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"> Если авторы <see langword="null"/>.</exception>
        public Kid(Name fullName, DateOnly dateBirth, Gender gender, params Employee[] employees)
            : this(fullName, dateBirth, new HashSet<Employee>(employees), gender)
        {
        }


        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Kid"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
        private Kid()
            : base(Name.Unknown)
        {
        }


        /// <summary>
        /// Работник.
        /// </summary>
        public ISet<Employee> Employees { get; set; } = new HashSet<Employee>();

        /// <summary>
        /// Добавление работника.
        /// </summary>
        /// <param name="employee">Работник.</param>
        /// <returns>Работник добавлен.</returns>
        public bool AddEmployee(Employee employee)
        {
            if (employee is null)
            {
                return false;
            }

            if (this.Employees.Add(employee))
            {
                _ = employee.Kids.Add(this);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Удаление работника.
        /// </summary>
        /// <param name="employee">Работник.</param>
        /// <returns>Работник удален.</returns>
        public bool RemoveEmployee(Employee employee)
        {
            if (employee is null)
            {
                return false;
            }

            if (!this.Employees.Remove(employee))
            {
                employee.Kids.Remove(this);
                return true;
            }

            return false;
        }
    }
}
