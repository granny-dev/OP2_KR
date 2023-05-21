using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class EmployeeTask
    {
        public int Id { get; set; } // Unique identifier for the task
        public string Title { get; set; }  // Title or name of the task    
        public string Status { get; set; } // Status of the task (e.g.,new, in progress, completed) 
        public string Priority { get; set; } // Priority level of the task (e.g., high, medium, low)
        public string Author { get; set; } // Author or creator of the task
        public string Executor { get; set; }  // Employee assigned to execute or work on the task
        public string Estimate { get; set; } // Estimated time required for the task
        public string Description { get; set; } // Detailed description or notes about the task

    }
}
