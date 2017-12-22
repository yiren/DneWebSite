using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DneWebSite.Models.Manhour
{
    public class Section
    {
        public Guid SectionId { get; set; }
        public string SectionName { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Task> Tasks { get; set; }

    }
}