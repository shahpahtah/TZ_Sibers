using Projects.contracts;
using Projects.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    public class ProjectEmployeeRepository:IProjectEmployeeRepository
    {
        private readonly ProjectManagementDbContext _context;

        public ProjectEmployeeRepository(ProjectManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(int projectId, int employeeId)
        {
            var projectEmployee = new ProjectEmployeeDto { ProjectId = projectId, EmployeeId = employeeId };
            _context.ProjectEmployees.Add(projectEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int projectId, int employeeId)
        {
            var projectEmployee = await _context.ProjectEmployees.FindAsync(projectId, employeeId);
            if (projectEmployee != null)
            {
                _context.ProjectEmployees.Remove(projectEmployee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
