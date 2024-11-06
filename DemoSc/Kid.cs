namespace DemoSc
{
    public class Kid : Human
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Kid"/> class.
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
    }
}
