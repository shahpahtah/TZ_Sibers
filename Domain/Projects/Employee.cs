namespace Projects
{
    public class Employee
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string MiddleName { get; }
        public string Email { get; }
        public IReadOnlyCollection<Project> Projects { get; } // IReadOnlyCollection для защиты от изменений

        public Employee(int id, string firstName, string lastName, string middleName, string email, IEnumerable<Project> projects)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Email = email;
            Projects = projects.ToList().AsReadOnly(); // Создаем ReadOnly копию списка
        }
    }
}