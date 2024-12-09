// <copyright file="Post.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DemoSc
{
    using Extensions;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Класс должность.
    /// </summary>
    public sealed class Post : Entity<Post>, IEquatable<Post>
    {

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Post"/> class.
        /// </summary>
        /// <param name="name">Название должности.</param>
        /// <param name="salary">Зароботная плата.</param>
        public Post(string name, decimal salary)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(salary);
            this.Salary = salary;
            this.Name = name.TrimOrNull() ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Работники.
        /// </summary>
        public ISet<Employee> Employees { get; } = new HashSet<Employee>();

        /// <summary>
        /// Добавить работника.
        /// </summary>
        /// <param name="employee">работник.</param>
        /// <returns>Должность.</returns>
        public bool AddEmployee(Employee employee)
        {
            return employee is not null
               && this.Employees.Add(employee)
               && (employee.Post = this) is not null;
        }

        /// <summary>
        /// Удалить работника.
        /// </summary>
        /// <param name="employee">Работник.</param>
        /// <returns>Работник удален.</returns>
        public bool RemoveEmployee(Employee employee)
        {
            return employee is not null
               && this.Employees.Remove(employee)
               && (employee.Post = this) is null;
        }

        /// <summary>
        /// Название должности.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Заработная плата.
        /// </summary>
        public decimal Salary { get; set; }

        /// <inheritdoc/>
        public bool Equals(Post? other)
        {
            return (other is not null) && (ReferenceEquals(this, other) && (this.Name == other.Name));
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Post);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() * this.Salary.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString() => $"Должность - {this.Name}, Зарплата - {this.Salary}";
    }
}
