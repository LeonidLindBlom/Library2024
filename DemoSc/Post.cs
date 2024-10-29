namespace DemoSc
{
    using Exeptions;

    public sealed class Post
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Post"/> class.
        /// </summary>
        /// <param name="name">Название должности.</param>
        /// <param name="salary">Зароботная плата.</param>
        public Post(string name, int salary)
        {
            this.ID = Guid.NewGuid();
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(salary);
            this.Salary = salary;
            this.Name = name.TrimOrNull() ?? throw new ArgumentNullException(nameof(name));
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
        public int Salary { get; }

        /// <inheritdoc/>
        public bool Equals(Post? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return false;
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
