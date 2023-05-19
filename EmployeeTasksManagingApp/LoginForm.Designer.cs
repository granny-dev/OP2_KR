namespace EmployeeTasksManagingApp
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameLbl = new MetroFramework.Controls.MetroLabel();
            this.passwordLbl = new MetroFramework.Controls.MetroLabel();
            this.loginBtn = new MetroFramework.Controls.MetroButton();
            this.nameText = new MetroFramework.Controls.MetroTextBox();
            this.passwordText = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(12, 105);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(45, 19);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "Name";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(12, 164);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(63, 19);
            this.passwordLbl.TabIndex = 2;
            this.passwordLbl.Text = "Password";
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(297, 234);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(90, 33);
            this.loginBtn.TabIndex = 2;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseSelectable = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // nameText
            // 
            // 
            // 
            // 
            this.nameText.CustomButton.Image = null;
            this.nameText.CustomButton.Location = new System.Drawing.Point(122, 2);
            this.nameText.CustomButton.Name = "";
            this.nameText.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.nameText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.nameText.CustomButton.TabIndex = 1;
            this.nameText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nameText.CustomButton.UseSelectable = true;
            this.nameText.CustomButton.Visible = false;
            this.nameText.Lines = new string[0];
            this.nameText.Location = new System.Drawing.Point(237, 105);
            this.nameText.MaxLength = 32767;
            this.nameText.Name = "nameText";
            this.nameText.PasswordChar = '\0';
            this.nameText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nameText.SelectedText = "";
            this.nameText.SelectionLength = 0;
            this.nameText.SelectionStart = 0;
            this.nameText.ShortcutsEnabled = true;
            this.nameText.Size = new System.Drawing.Size(150, 30);
            this.nameText.TabIndex = 3;
            this.nameText.UseSelectable = true;
            this.nameText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nameText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // passwordText
            // 
            // 
            // 
            // 
            this.passwordText.CustomButton.Image = null;
            this.passwordText.CustomButton.Location = new System.Drawing.Point(122, 2);
            this.passwordText.CustomButton.Name = "";
            this.passwordText.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.passwordText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordText.CustomButton.TabIndex = 1;
            this.passwordText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordText.CustomButton.UseSelectable = true;
            this.passwordText.CustomButton.Visible = false;
            this.passwordText.Lines = new string[0];
            this.passwordText.Location = new System.Drawing.Point(237, 153);
            this.passwordText.MaxLength = 32767;
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '\0';
            this.passwordText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordText.SelectedText = "";
            this.passwordText.SelectionLength = 0;
            this.passwordText.SelectionStart = 0;
            this.passwordText.ShortcutsEnabled = true;
            this.passwordText.Size = new System.Drawing.Size(150, 30);
            this.passwordText.TabIndex = 4;
            this.passwordText.UseSelectable = true;
            this.passwordText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passwordText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 290);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.nameLbl);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel nameLbl;
        private MetroFramework.Controls.MetroLabel passwordLbl;
        private MetroFramework.Controls.MetroButton loginBtn;
        private MetroFramework.Controls.MetroTextBox nameText;
        private MetroFramework.Controls.MetroTextBox passwordText;
    }
}