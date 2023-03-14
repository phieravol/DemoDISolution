using System;
using System.Collections.Generic;

namespace DemoDISolution.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Gender { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
    }
}
