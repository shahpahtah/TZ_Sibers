using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.data
{
    public class ProjectDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string CustomerCompany { get; set; }
        [MaxLength(255)]
        public string ExecutorCompany { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public int? ProjectManagerId { get; set; }
        [ForeignKey("ProjectManagerId")]
        public EmployeeDto ProjectManager { get; set; }
        public ICollection<ProjectEmployeeDto> ProjectEmployees { get; set; } = new List<ProjectEmployeeDto>();
    }

}
