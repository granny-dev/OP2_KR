using BusinessLibrary;
using Dapper;
using DataAccessLibrary;
using ModelLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeTasksManagingApp
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        // Create an instance of the database context
        IDbContext db = new DbContext();

        // Create an instance of the Employee class
        Employee emp = new Employee();

        // Create an instance of the EmployeeOperations class
        EmployeeOperations empOperations;

        // Create an instance of the TaskManagingForm class
        TaskManagingForm taskManagingForm = new TaskManagingForm();


        public LoginForm()
        {
            InitializeComponent();

            // Initialize the EmployeeOperations instance with the database context
            empOperations = new EmployeeOperations(db);
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Set the employee's name and password based on the input fields
                emp.Name = nameText.Text;
                emp.Password = passwordText.Text;

                // Call the Login method of the EmployeeOperations instance   
                var result = empOperations.Login(emp);

                // Check the result to determine the role of the employee
                    if (result == "ProjectManager")
                    {
                    // Show a message box indicating the role
                        MessageBox.Show("ProjectManager");

                    // Hide the login form and show the task managing form
                        this.Hide();
                        taskManagingForm.Show();
                    }
                    else if (result == "Developer")
                    {
                        MessageBox.Show("Developer");
                        this.Hide();
                        taskManagingForm.Show();

                    }
                    else if (result == "QA")
                    {
                        MessageBox.Show("QA");
                        this.Hide();
                        taskManagingForm.Show();
                    }
                    else
                    {
                        // Show an error message for incorrect name or password
                        MessageBox.Show("Incorrect name or password");
                    }
                               
            }
            catch (Exception ex)
            {
                // Display a MetroMessageBox with the error message
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
