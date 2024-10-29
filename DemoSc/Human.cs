namespace DemoSc
{
    using Exeptions;

    public abstract class Human
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Human"/> class.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="patronicName">Отчество.</param>
        /// <param name="dateBirth">Дата рождения.</param>
        public Human(string firstName, string lastName, string patronicName, DateOnly dateBirth)
        {
            this.ID = Guid.NewGuid();
            this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentNullException(nameof(firstName));
            this.LastName = lastName.TrimOrNull() ?? throw new ArgumentNullException(nameof(lastName));
            this.PatronicName = patronicName.TrimOrNull() ?? throw new ArgumentNullException(nameof(patronicName));
            this.DateBirth = dateBirth;
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
        /// Отчество
        /// </summary>
        public string PatronicName { get; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateOnly? DateBirth { get; }

        /// /// <inheritdoc/>
        public bool Equals(Human? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.FirstName != other.FirstName
                || this.LastName != other.LastName
                || this.PatronicName != other.PatronicName)
            {
                return false;
            }

            if (((this.DateBirth is not null) && (other.DateBirth is null))
                || ((this.DateBirth is null) && (other.DateBirth is not null)))
            {
                return false;
            }

            if (this.DateBirth != other.DateBirth)
            {
                return false;
            }

            return true;
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
