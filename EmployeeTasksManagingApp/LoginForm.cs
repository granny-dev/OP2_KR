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
        IDbContext db = new DbContext();
        Employee emp = new Employee();
        EmployeeOperations empOperations;
        TaskManagingForm taskManagingForm = new TaskManagingForm();


        public LoginForm()
        {
            InitializeComponent();
            empOperations = new EmployeeOperations(db);
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                emp.Name = nameText.Text;
                emp.Password = passwordText.Text;

                   
                var result = empOperations.Login(emp);

                
                    if (result == "ProjectManager")
                    {
                        MessageBox.Show("ProjectManager");
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
                    MessageBox.Show("Incorrect name or password");
                    }
                               
            }
            catch (Exception ex)
            {

                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
