// <copyright file="Human.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DemoSc
{
    using System;
    using System.Text;

    /// <summary>
    /// Класс Человек.
    /// </summary>
    public abstract class Human<THuman> : Entity<THuman>
        where THuman : Human<THuman>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Human{THuman}"/>.
        /// </summary>
        /// <param name="fullName"> Полное имя.</param>
        /// <param name="dateBirth"> Дата рождения. </param>
        /// <param name="gender"> Пол. </param>
        /// <exception cref="ArgumentNullException">
        /// Если Полное имя <see langword="null"/>.
        /// </exception>
        protected Human(
            Name fullName,
            DateOnly? dateBirth = null,
            Gender gender = Gender.Unknow)
        {
            this.FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            this.DateBirth = dateBirth;
            this.Gender = gender;
        }

        /// <summary>
        /// Имя.
        /// </summary>
        public Name FullName { get; }

        /// <summary>
        /// Дата р
        /// </summary>
        public DateOnly? DateBirth { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is THuman person && this.Equals(person);
        }

        /// <inheritdoc/>
        public override bool Equals(THuman? other)
        {
            return base.Equals(other)
                && this.FullName == other.FullName
                && this.DateBirth == other.DateBirth;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(this.FullName, this.DateBirth);

        /// <inheritdoc/>
        public override string ToString()
        {
            var buffer = new StringBuilder();
            _ = buffer.Append(this.FullName);

            if (this.DateBirth is not null)
            {
                _ = buffer.Append($" Год рождения: {this.DateBirth}");
            }

            return buffer.ToString();
        }
    }
}
