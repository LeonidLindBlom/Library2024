// <copyright file="Post.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DemoSc
{
    using Exeptions;

    /// <summary>
    /// Класс должность.
    /// </summary>
    public sealed class Post : IEquatable<Post>
    {
        [Obsolete("For ORM only")]
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
        private Post()
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Post"/> class.
        /// </summary>
        /// <param name="name">Название должности.</param>
        /// <param name="salary">Зароботная плата.</param>
        public Post(string name, decimal salary)
        {
            this.ID = Guid.Empty;
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(salary);
            this.Salary = salary;
            this.Name = name.TrimOrNull() ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Работники.
        /// </summary>
        public ISet<Employee> Employees { get; set; } = new HashSet<Employee>();

        /// <summary>
        /// Добавить работника.
        /// </summary>
        /// <param name="employee">работник.</param>
        /// <returns>Должность.</returns>
        public Post AddEmployee(Employee employee)
        {
            ArgumentNullException.ThrowIfNull(employee);

            this.Employees.Add(employee);
            employee.Post = this;
            return this;
        }

        /// <summary>
        /// Удалить работника.
        /// </summary>
        /// <param name="employee">Работник.</param>
        /// <returns>Работник удален.</returns>
        public Post RemoveEmployee(Employee employee)
        {
            this.Employees.Remove(employee);
            employee.Post = null;
            return this;
        }


        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid ID { get; }

        /// <summary>
        /// Название должности.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Заработная плата.
        /// </summary>
        public decimal Salary { get; }

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
