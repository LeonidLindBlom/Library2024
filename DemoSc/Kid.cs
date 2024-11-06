// <copyright file="Kid.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DemoSc
{
    /// <summary>
    /// Класс ребенок.
    /// </summary>
    public class Kid : Human
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Kid"/>.
        /// </summary>
        /// <param name="firstName"> Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="patronicName">Отчество.</param>
        /// <param name="dateBirth">Дата рорждения.</param>
        /// <param name="employee">Работник.</param>
        /// <param name="gender">Пол.</param>
        public Kid(string firstName, string lastName, string patronicName, DateOnly dateBirth, Employee employee, Gender gender)
            : base(firstName, lastName, patronicName, dateBirth, gender)
        {
            this.Employee = employee;
        }

        /// <summary>
        /// Работник.
        /// </summary>
        public Employee Employee { get; }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            var temp = obj as Kid;
            Employee employee = temp.Employee;
            return base.Equals((Human?)temp) && this.Employee == employee;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
