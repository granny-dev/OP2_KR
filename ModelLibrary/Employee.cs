using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Employee
    {
        public int Id { get; set; } // Unique identifier for the employee
        public string Name { get; set; } // Name of the employee
        public string Role { get; set; } // Role or position of the employee
        public string Password { get; set; } // Password associated with the employee
    }
}
