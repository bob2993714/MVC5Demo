using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models
{
    public class DepartmentEdit
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<int> InstructorID { get; set; }
    }
}