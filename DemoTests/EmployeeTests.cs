namespace DemoTests
{
    using DemoSc;

    [TestFixture]
    internal class EmployeeTests
    {
        private static readonly Post Post = new ("Тестовое название", 10000);

        [Test]
        public void Ctor_ValidDate_DoesNotThrow()
        {
            var dateBirth = new DateOnly(2002, 09, 08);
            Assert.DoesNotThrow(() =>
            _ = new Employee("Толстой", "Лев", "Акакиевич", dateBirth, Gender.Male, Post, Post.ID));
        }
    }
}
