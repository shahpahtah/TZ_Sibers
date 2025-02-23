using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Projects.data;

public class ProjectManagementDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<ProjectDto> Projects { get; set; }
    public DbSet<EmployeeDto> Employees { get; set; }
    public DbSet<ProjectEmployeeDto> ProjectEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ProjectManagementConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка связей и ограничений с использованием Fluent API

        // Связь Project <-> Employee (многие ко многим) через ProjectEmployee
        modelBuilder.Entity<ProjectDto>()
            .HasMany(p => p.ProjectEmployees)
            .WithOne(pe => pe.Project) // Исправлено: WithRequired -> WithOne
            .HasForeignKey(pe => pe.ProjectId)
            .OnDelete(DeleteBehavior.Restrict); // Отключаем каскадное удаление

        modelBuilder.Entity<EmployeeDto>()
            .HasMany(e => e.ProjectEmployees)
            .WithOne(pe => pe.Employee) // Исправлено: WithRequired -> WithOne
            .HasForeignKey(pe => pe.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict); // Отключаем каскадное удаление

        modelBuilder.Entity<ProjectEmployeeDto>()
            .HasKey(pe => new { pe.ProjectId, pe.EmployeeId }); // Составной первичный ключ

        // Связь Project -> ProjectManager (один ко многим)
        modelBuilder.Entity<ProjectDto>()
            .HasOne(p => p.ProjectManager) // Исправлено: HasOptional -> HasOne
            .WithMany() // Без обратной навигации
            .HasForeignKey(p => p.ProjectManagerId)
            .IsRequired(false) // Указываем, что связь необязательная
            .OnDelete(DeleteBehavior.Restrict);

        // Отключаем каскадное удаление для связей многие ко многим

        base.OnModelCreating(modelBuilder);
    }
}