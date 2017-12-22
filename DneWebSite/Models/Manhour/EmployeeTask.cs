using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DneWebSite.Models.Manhour
{
    public class EmployeeTask
    {
        public Guid EmployeeTaskId { get; set; }

        public float Manhour { get; set; }
        public short TaskYear { get; set; }
        public short WeekofYear { get; set; }
        public DateTime TaskDate { get; set; }


        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Guid TaskId { get; set; }
        public Task Task { get; set; }

    }

    public class ManhourPostViewModel
    {
        public Guid EmpolyeeId { get; set; }

        public Guid SectionId { get; set; }

        public DateTime TaskDate { get; set; }
        
        public List<EmployeeTask> EmployeeTasks { get; set; }
        
    }

    public class ManhourQueryByDateViewModel
    {
        public Guid EmployeeId { get; set; }

        public string TaskStartDate { get; set; }

        public string TaskEndDate { get; set; }

    }
}