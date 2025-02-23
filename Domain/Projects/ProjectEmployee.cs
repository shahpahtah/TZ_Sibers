using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects
{
    public class ProjectEmployee
    {
        public int ProjectId { get; }
        public int EmployeeId { get; }

        public ProjectEmployee(int projectId, int employeeId)
        {
            ProjectId = projectId;
            EmployeeId = employeeId;
        }
    }
}
