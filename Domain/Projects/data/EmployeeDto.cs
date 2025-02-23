using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.data
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
        [MaxLength(255)]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        public ICollection<ProjectEmployeeDto> ProjectEmployees { get; set; } = new List<ProjectEmployeeDto>();
    }
}
