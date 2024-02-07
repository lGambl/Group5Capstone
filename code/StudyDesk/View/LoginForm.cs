using StudyDesk.Controller;
using StudyDesk.Model;

namespace StudyDesk.View;

/// <summary>
///     The login screen form.
/// </summary>
/// <seealso cref="System.Windows.Forms.Form" />
public partial class LoginForm : Form
{
    #region Data members

    private const string InvalidLoginMessage = "Invalid Username or password";
    private const string? LoginFailed = "Login Failed";

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="LoginForm" /> class.
    /// </summary>
    public LoginForm()
    {
        this.InitializeComponent();
        this.centerForm();
    }

    #endregion

    #region Methods

    private void centerForm()
    {
        StartPosition = FormStartPosition.CenterScreen;
    }

    private void LoginButton_Click(object sender, EventArgs e)
    {
        var loginController = new LoginController(new AuthService());
        var auth = loginController.VerifyLoginCredentials(this.UsernameTextBox.Text, this.PasswordTextBox.Text);
        if (auth != null)
        {
            var mainpage = new MainPageForm(auth);
            mainpage.Show();
            mainpage.Closed += (_, _) => Close();
            Hide();
        }
        else
        {
            MessageBox.Show(InvalidLoginMessage, LoginFailed, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void newUserButton_Click(object sender, EventArgs e)
    {
        var registrationPage = new UserRegistrationForm();
        registrationPage.Show();
        registrationPage.Closed += (_, _) => Close();
        Hide();
    }

    #endregion
}