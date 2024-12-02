// <copyright file="Employee.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DemoSc
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Класс работник.
    /// </summary>
    public sealed class Employee : Human<Employee>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Employee"/>.
        /// </summary>
        /// <param name="fullName"> Полное имя.</param>
        /// <param name="dateBirth">День рождения.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="post">Должность.</param>
        public Employee(Name fullName, DateOnly dateBirth, Gender gender, Post post)
            : base(fullName, dateBirth, gender)
        {
            if (this.Post is not null)
            {
                _ = this.Post.AddEmployee(this);
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Employee"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
        private Employee() 
            : base(Name.Unknown, DateOnly.MaxValue, Gender.Unknow)
        {
        }

        /// <summary>
        /// Работники с детьми.
        /// </summary>
        public ISet<Kid> Kids { get; set; } = new HashSet<Kid>();

        /// <summary>
        /// Добавление ребенка.
        /// </summary>
        /// <param name="kid">Ребенок.</param>
        /// <returns>Ребенок добавлен.</returns>
        public bool AddKid(Kid kid)
        {
            if (kid is null)
            {
                return false;
            }

            if (this.Kids.Add(kid))
            {
                _ = kid.Employees.Add(this);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Удаление рребенка.
        /// </summary>
        /// <param name="kid">Ребенок.</param>
        /// <returns>Ребенок удален.</returns>
        public bool RemoveKid(Kid kid)
        {
            if (kid is null)
            {
                return false;
            }

            if (!this.Kids.Remove(kid))
            {
                kid.Employees.Remove(this);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Должность.
        /// </summary>
        public Post Post { get; set; }
    }
}
