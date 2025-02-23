using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Projects;
using Projects.contracts;
using Projects.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly ProjectManagementDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(ProjectManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employeeDb = await _context.Employees.FindAsync(id);
            return _mapper.Map<Employee>(employeeDb);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employeeDbs = await _context.Employees.ToListAsync();
            return _mapper.Map<List<Employee>>(employeeDbs);
        }

        public async Task AddAsync(Employee employee)
        {
            var employeeDb = _mapper.Map<EmployeeDto>(employee);
            _context.Employees.Add(employeeDb);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            var employeeDb = _mapper.Map<EmployeeDto>(employee);
            _context.Entry(employeeDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employeeDb = await _context.Employees.FindAsync(id);
            if (employeeDb != null)
            {
                _context.Employees.Remove(employeeDb);
                await _context.SaveChangesAsync();
            }
        }
    }
}
