using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.contracts
{
    public interface IProjectEmployeeRepository
    {
        Task AddAsync(int projectId, int employeeId);
        Task DeleteAsync(int projectId, int employeeId);
    }
}
