using StudyDesk.Controller;

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
        if (LoginController.VerifyLoginCredentials(this.UsernameTextBox.Text, this.PasswordTextBox.Text))
        {
            var mainpage = new MainPageForm();
            mainpage.Show();
            mainpage.Closed += (_, _) => Close();
            Hide();
        }
        else
        {
            MessageBox.Show(InvalidLoginMessage,LoginFailed, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    #endregion
}