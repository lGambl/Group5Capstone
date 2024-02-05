using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StudyDesk.View
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
            UsernameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            LoginButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(144, 151);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.PlaceholderText = "Username";
            UsernameTextBox.Size = new Size(125, 27);
            UsernameTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(144, 208);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.PlaceholderText = "Password";
            PasswordTextBox.Size = new Size(125, 27);
            PasswordTextBox.TabIndex = 1;
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(160, 271);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(94, 37);
            LoginButton.TabIndex = 2;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Magneto", 25F);
            label1.Location = new Point(69, 97);
            label1.Name = "label1";
            label1.Size = new Size(277, 51);
            label1.TabIndex = 3;
            label1.Text = "StudyDesk";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 155);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 4;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 212);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 5;
            label3.Text = "Password";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 380);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LoginButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(UsernameTextBox);
            ForeColor = Color.Black;
            Name = "LoginForm";
            Text = "LoginScreen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameTextBox;
        private TextBox PasswordTextBox;
        private Button LoginButton;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
