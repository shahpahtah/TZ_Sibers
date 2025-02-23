using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.contracts
{
    public interface IProjectRepository
    {
            Task<Project> GetByIdAsync(int id);
            Task<IEnumerable<Project>> GetAllAsync();
            Task AddAsync(Project project);
            Task UpdateAsync(Project project);
            Task DeleteAsync(int id);
            Task<IEnumerable<Employee>> GetEmployeesByProjectIdAsync(int projectId);

    }
}
