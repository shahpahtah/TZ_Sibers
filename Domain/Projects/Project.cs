using Projects.data;

namespace Projects
{
    public class Project
    {

        public int Id { get; }
        public string Name { get; }
        public string CustomerCompany { get; }
        public string ExecutorCompany { get; }
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
        public int Priority { get; }
        public int? ProjectManagerId { get; }
        public Employee ProjectManager { get; }
        public IReadOnlyCollection<Employee> Employees { get; } // IReadOnlyCollection для защиты от изменений

        public Project(int id, string name, string customerCompany, string executorCompany, DateTime startDate, DateTime? endDate, int priority, int? projectManagerId, Employee projectManager, IEnumerable<Employee> employees)
        {
            // Валидация входных параметров (например, проверка на null, пустые строки, допустимые значения)
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }

            Id = id;
            Name = name;
            CustomerCompany = customerCompany;
            ExecutorCompany = executorCompany;
            StartDate = startDate;
            EndDate = endDate;
            Priority = priority;
            ProjectManagerId = projectManagerId;
            ProjectManager = projectManager;
            Employees = employees.ToList().AsReadOnly(); // Создаем ReadOnly копию списка
        }

        // Другие методы, реализующие бизнес-логику (например, CalculateDuration, AssignEmployee)
    }
    
}
