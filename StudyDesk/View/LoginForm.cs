using StudyDesk.Model;
using System.Text;

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
        // private readonly LoginController controller;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="LoginForm" /> class.
        /// </summary>
        public LoginForm()
        {
            this.InitializeComponent();
            this.centerForm();
            // this.controller = new LoginController();
        }

        #endregion

        #region Methods

        private void centerForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // this.controller.CurrentEmployee =
            //     LoginController.CheckLogin(this.UsernameTextBox.Text, this.PasswordTextBox.Text);
            // if (this.controller.CurrentEmployee != null)
            // {
            //     var mainpageContgroller = new MainpageController
            //     {
            //         CurrentEmployee = this.controller.CurrentEmployee
            //     };
            //     var mainpage = new Mainpage(mainpageContgroller);
            //     mainpage.Show();
            //     mainpage.Closed += (_, _) => Close();
            //     Hide();
            // }
            // else
            // {
            //     MessageBox.Show(InvalidLoginMessage);
            // }
        }

        #endregion

    }
}
