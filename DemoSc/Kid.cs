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
        public Kid(string firstName, string lastName, string patronicName, DateOnly dateBirth, Employee employee, Gender gender) 
            : base(firstName, lastName, patronicName, dateBirth, gender)
        {
            this.EmployeeID = employee.ID;
            this.Gender = gender;
        }

        /// <summary>
        /// Идентификатор работника.
        /// </summary>
        public Guid EmployeeID { get; }


        public Gender Gender { get; }
    }
}
