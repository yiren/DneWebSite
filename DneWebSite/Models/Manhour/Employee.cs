using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DneWebSite.Models.Manhour
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public List<EmployeeTask> EmployeeTasks { get; set; }
        public Section Section { get; set; }
        public Guid SectionId { get; set; }
    }
}