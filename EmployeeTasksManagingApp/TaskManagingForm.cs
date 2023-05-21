using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BusinessLibrary;
using DataAccessLibrary;
using MetroFramework.Controls;
using ModelLibrary;

namespace EmployeeTasksManagingApp
{
    public partial class TaskManagingForm : MetroFramework.Forms.MetroForm
    {
        IDbContext db = new DbContext();
        EmployeeTaskOperations taskOperations;
        TaskState state = TaskState.Unchanged;
        EmployeeTask task = new EmployeeTask();
       
        MetroGrid grid = new MetroGrid();
       
        public TaskManagingForm()
        {
            InitializeComponent();
            taskOperations = new EmployeeTaskOperations(db);

        }

        // Form load event handler
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Load all employee tasks into the binding source
                employeeTaskBindingSource.DataSource = taskOperations.GetAll();
                    task = employeeTaskBindingSource.Current as EmployeeTask;                
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add button click event handler
        private void addBtn_Click(object sender, EventArgs e)
        {
            state = TaskState.Added;
            employeeTaskBindingSource.Add(task);
        }

        // Edit button click event handler
        private void editBtn_Click(object sender, EventArgs e)
        {
            state = TaskState.Changed;

        }

        // MetroGrid cell click event handler
        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            try
            {
                // Get the currently selected employee task
                task = employeeTaskBindingSource.Current as EmployeeTask;
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delete button click event handler
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            state = TaskState.Deleted;
            if(MetroFramework.MetroMessageBox.Show(this, "Delete task?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Delete the selected employee task
                    task = employeeTaskBindingSource.Current as EmployeeTask;
                    if(task != null)
                    {
                       bool result = taskOperations.Delete(task.Id);
                        if(result)
                        {
                            // Remove the task from the binding source and refresh the grid
                            employeeTaskBindingSource.RemoveCurrent();
                            grid.Refresh();
                            state = TaskState.Unchanged;
                        }                        
                    }                    
                }
                catch (Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }           
        }

        // Save button click event handler
        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // End editing on the binding source and save the changes
                employeeTaskBindingSource.EndEdit();              
                task = employeeTaskBindingSource.Current as EmployeeTask;
                if (task != null)
                {                    
                        taskOperations.Save(task, state);
                        grid.Refresh();
                        state = TaskState.Unchanged;                                    
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
