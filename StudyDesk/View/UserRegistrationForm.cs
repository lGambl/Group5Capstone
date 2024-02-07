using StudyDesk.Controller;

namespace StudyDesk.View
{
    /// <summary>
    ///   The User Registration Form
    /// </summary>
    public partial class UserRegistrationForm : Form
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="UserRegistrationForm" /> class.
        /// </summary>
        public UserRegistrationForm()
        {
            InitializeComponent();
            this.centerForm();
        }

        private void centerForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void createUserButton_Click(object sender, EventArgs e)
        {
            if (!this.passwordTextBox.Text.Equals(this.passwordConfirmationTextBox.Text))
            {
                MessageBox.Show("Password must match. Please try again.", "Password Mismatch", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                var result = new UserRegistrationController().CreateNewUser(this.emailTextBox.Text, this.emailTextBox.Text, this.passwordTextBox.Text);

                if (result.Result)
                {
                    MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var loginPage = new LoginForm();
                    loginPage.Show();
                    loginPage.Closed += (_, _) => Close();
                    Hide();
                }
                else
                {
                    MessageBox.Show("User registration failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
