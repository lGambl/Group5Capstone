using StudyDesk.Model;
using System.Text;
using StudyDesk.Controller;

namespace StudyDesk.View
{
    /// <summary>
    ///     The login screen form.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class LoginForm : Form
    {
        #region Data members

        private const string InvalidLoginMessage = "Invalid Username or password"; 
        private readonly LoginController controller;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="LoginForm" /> class.
        /// </summary>
        public LoginForm()
        {
            this.InitializeComponent();
            this.centerForm();
            this.controller = new LoginController();
        }

        #endregion

        #region Methods

        private void centerForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (this.controller.VerifyLoginCredentials(this.UsernameTextBox.Text, this.PasswordTextBox.Text))
            {
                var mainpage = new MainPageForm(string.Empty);
                mainpage.Show();
                mainpage.Closed += (_, _) => Close();
                Hide();
            }
            else
            {
                MessageBox.Show("Please enter valid login credentials.", "Login Failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        #endregion

    }
}
