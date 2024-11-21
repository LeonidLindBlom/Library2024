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
        [Obsolete("For ORM only")]
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
        private Kid()
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Kid"/>.
        /// </summary>
        /// <param name="firstName"> Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="patronicName">Отчество.</param>
        /// <param name="dateBirth">Дата рорждения.</param>
        /// <param name="employees">Работник.</param>
        /// <param name="gender">Пол.</param>
        public Kid(string firstName, string lastName, string patronicName, DateOnly dateBirth, ISet<Employee> employees, Gender gender)
            : base(firstName, lastName, patronicName, dateBirth, gender)
        {
            this.Employees = employees;
            foreach (var employee in employees)
            {
                employee.AddKid(this);
            }
        }

        public Kid(string firstName, string lastName, string patronicName, DateOnly dateBirth, Gender gender, params Employee[] employees) 
            : this(firstName, lastName, patronicName, dateBirth, new HashSet<Employee>(employees), gender)
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

        /// <inheritdoc/>
        public bool Equals(object? obj)
        {
            var temp = obj as Kid;
            ISet<Employee> employee = temp.Employees;
            return base.Equals((Human?)temp) && this.Employees == employee;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
