// <copyright file="Human.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DemoSc
{
    using Extensions;

    /// <summary>
    /// Класс Человек.
    /// </summary>
    public abstract class Human : IEquatable<Human>
    {
        [Obsolete("For ORM only")]
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
        protected Human()
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
        {
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Human"/>.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="patronicName">Отчество.</param>
        /// <param name="dateBirth">Дата рождения.</param>
        /// <param name="gender">Пол.</param>
        protected Human(string firstName, string lastName, string patronicName, DateOnly dateBirth, Gender gender)
        {
            this.ID = Guid.NewGuid();
            this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentNullException(nameof(firstName));
            this.LastName = lastName.TrimOrNull() ?? throw new ArgumentNullException(nameof(lastName));
            this.PatronicName = patronicName.TrimOrNull() ?? throw new ArgumentNullException(nameof(patronicName));
            this.DateBirth = dateBirth;
            this.Gender = gender;
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid ID { get; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string PatronicName { get; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateOnly? DateBirth { get; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; }

        /// <inheritdoc/>
        public bool Equals(Human? other)
        {
            return other is not null
                 && this.LastName == other.LastName
                 && this.FirstName == other.FirstName
                 && this.PatronicName == other.PatronicName
                 && this.DateBirth == other.DateBirth
                 && this.Gender == other.Gender;
}

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Human);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() * this.LastName.GetHashCode() * this.PatronicName.GetHashCode() * this.DateBirth.GetHashCode();
        }
    }
}
