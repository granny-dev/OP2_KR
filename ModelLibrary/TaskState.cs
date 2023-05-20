using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public enum TaskState
    {
        Unchanged,  // The task is in its original state, without any changes
        Added,      // The task is newly added and pending further action
        Changed,    // The task has been modified
        Deleted     // The task has been marked for deletion

    }
}
