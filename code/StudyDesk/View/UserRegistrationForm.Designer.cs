namespace StudyDesk.View
{
    partial class UserRegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserRegistrationForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            emailTextBox = new TextBox();
            passwordTextBox = new TextBox();
            passwordConfirmationTextBox = new TextBox();
            createUserButton = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Magneto", 25F);
            label1.Location = new Point(47, 41);
            label1.Name = "label1";
            label1.Size = new Size(226, 41);
            label1.TabIndex = 4;
            label1.Text = "StudyDesk";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(115, 124);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 5;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 158);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 6;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 189);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 7;
            label4.Text = "Confirm Password";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(173, 121);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(100, 23);
            emailTextBox.TabIndex = 8;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(173, 155);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(100, 23);
            passwordTextBox.TabIndex = 9;
            // 
            // passwordConfirmationTextBox
            // 
            passwordConfirmationTextBox.Location = new Point(173, 189);
            passwordConfirmationTextBox.Name = "passwordConfirmationTextBox";
            passwordConfirmationTextBox.PasswordChar = '*';
            passwordConfirmationTextBox.Size = new Size(102, 23);
            passwordConfirmationTextBox.TabIndex = 10;
            // 
            // createUserButton
            // 
            createUserButton.Location = new Point(115, 319);
            createUserButton.Name = "createUserButton";
            createUserButton.Size = new Size(102, 46);
            createUserButton.TabIndex = 11;
            createUserButton.Text = "Create User";
            createUserButton.UseVisualStyleBackColor = true;
            createUserButton.Click += createUserButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(2, 226);
            label5.Name = "label5";
            label5.Size = new Size(335, 90);
            label5.TabIndex = 12;
            label5.Text = resources.GetString("label5.Text");
            // 
            // UserRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 404);
            Controls.Add(label5);
            Controls.Add(createUserButton);
            Controls.Add(passwordConfirmationTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "UserRegistrationForm";
            Text = "UserRegistrationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox emailTextBox;
        private TextBox passwordTextBox;
        private TextBox passwordConfirmationTextBox;
        private Button createUserButton;
        private Label label5;
    }
}