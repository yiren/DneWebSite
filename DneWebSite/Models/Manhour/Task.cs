using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DneWebSite.Models.Manhour
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public string TaskName { get; set; }

        public Section Section { get; set; }
        public Guid SectionId { get; set; }

        public List<EmployeeTask> EmployeeTasks { get; set; }
    }
}