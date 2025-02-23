using Microsoft.EntityFrameworkCore;
using Projects;
using Projects.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Projects.data;
namespace Data.EF.Repositories
{
   public  class ProjectRepository : IProjectRepository
    {
        private readonly ProjectManagementDbContext _context;
        private readonly IMapper _mapper;

        public ProjectRepository(ProjectManagementDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var projectDb = await _context.Projects
                .Include(p => p.ProjectEmployees)
                .ThenInclude(pe => pe.Employee)
                .FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<Project>(projectDb);
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            var projectDbs = await _context.Projects
                .Include(p => p.ProjectEmployees)
                .ThenInclude(pe => pe.Employee)
                .ToListAsync();

            return _mapper.Map<List<Project>>(projectDbs);
        }

        public async Task AddAsync(Project project)
        {
            var projectDb = _mapper.Map<ProjectDto>(project);
            _context.Projects.Add(projectDb);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            var projectDb = _mapper.Map<ProjectDto>(project);
            _context.Entry(projectDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var projectDb = await _context.Projects.FindAsync(id);
            if (projectDb != null)
            {
                _context.Projects.Remove(projectDb);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByProjectIdAsync(int projectId)
        {
            var projectDb = await _context.Projects
                .Include(p => p.ProjectEmployees)
                .ThenInclude(pe => pe.Employee)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (projectDb == null)
            {
                return null;
            }

            return _mapper.Map<List<Employee>>(projectDb.ProjectEmployees.Select(pe => pe.Employee));
        }
    }
}

