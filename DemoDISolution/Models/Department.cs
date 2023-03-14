using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoDISolution.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [Display(Name = "Department Name")]
        public string? DepartmentName { get; set; }

        [Required(ErrorMessage = "Address name is required")]
        [Display(Name = "Address")]
        public string? Address { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
