using System;
using System.Collections.Generic;

namespace DemoDISolution.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
