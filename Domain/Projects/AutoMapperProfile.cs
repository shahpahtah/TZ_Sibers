using AutoMapper;
using Projects;
using Projects.data;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // ProjectDb -> Project
        CreateMap<ProjectDto, Project>()
            .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.ProjectEmployees.Select(pe => pe.Employee).ToList()))
             .ForCtorParam("employees", opt => opt.MapFrom(src => src.ProjectEmployees.Select(pe => pe.Employee).ToList()))
            .ForCtorParam("id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("name", opt => opt.MapFrom(src => src.Name))
            .ForCtorParam("customerCompany", opt => opt.MapFrom(src => src.CustomerCompany))
            .ForCtorParam("executorCompany", opt => opt.MapFrom(src => src.ExecutorCompany))
            .ForCtorParam("startDate", opt => opt.MapFrom(src => src.StartDate))
            .ForCtorParam("endDate", opt => opt.MapFrom(src => src.EndDate))
            .ForCtorParam("priority", opt => opt.MapFrom(src => src.Priority))
            .ForCtorParam("projectManagerId", opt => opt.MapFrom(src => src.ProjectManagerId))
            .ForCtorParam("projectManager", opt => opt.MapFrom(src => src.ProjectManager));

        // Project -> ProjectDb
        CreateMap<Project, ProjectDto>()
             .ForMember(dest => dest.ProjectEmployees, opt => opt.MapFrom(src => src.Employees.Select(e => new ProjectEmployeeDto { EmployeeId = e.Id }).ToList()));

        // EmployeeDb -> Employee
        CreateMap<EmployeeDto, Employee>()
            .ForCtorParam("id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("firstName", opt => opt.MapFrom(src => src.FirstName))
            .ForCtorParam("lastName", opt => opt.MapFrom(src => src.LastName))
            .ForCtorParam("middleName", opt => opt.MapFrom(src => src.MiddleName))
            .ForCtorParam("email", opt => opt.MapFrom(src => src.Email));

        // Employee -> EmployeeDb
        CreateMap<Employee, EmployeeDto>();

        // ProjectEmployeeDb -> ProjectEmployee (если требуется)
        CreateMap<ProjectEmployeeDto, ProjectEmployee>();

        // ProjectEmployee -> ProjectEmployeeDb (если требуется)
        CreateMap<ProjectEmployee, ProjectEmployeeDto>();
    }
}