using System.Text.RegularExpressions;
using StudyDesk.Controller;

namespace StudyDesk.View;

/// <summary>
///     The User Registration Form
/// </summary>
public partial class UserRegistrationForm : Form
{
    private const string? InvalidEmailAddress = "Invalid email address.";
    private const string? InvalidEmail = "Invalid Email";
    private const string PasswordRegex = "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\\W_]).{6,}$";

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="UserRegistrationForm" /> class.
    /// </summary>
    public UserRegistrationForm()
    {
        this.InitializeComponent();
        this.centerForm();
        this.emailTextBox.LostFocus += this.emailTextBox_FocusChanges;
        this.FormClosing += this.onClosing;
    }

    #endregion

    #region Methods

    private void centerForm()
    {
        StartPosition = FormStartPosition.CenterScreen;
    }

    private void createUserButton_Click(object sender, EventArgs e)
    {
        if (!this.doPasswordsMatch())
        {
            MessageBox.Show("Password must match. Please try again.", "Password Mismatch", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        else if (this.isValidPassword())
        {
            MessageBox.Show("Password is invalid. Please try again.", "Invalid Password", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        else if (!this.isValidEmail(this.emailTextBox.Text))
        {
            MessageBox.Show(InvalidEmailAddress, InvalidEmail, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            var result = new UserRegistrationController().CreateNewUser(this.emailTextBox.Text, this.emailTextBox.Text,
                this.passwordTextBox.Text);

            if (result.Result)
            {
                MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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

    private bool isValidPassword()
    {
        var regex = new Regex(PasswordRegex);
        return !regex.IsMatch(this.passwordTextBox.Text);
    }

    private bool doPasswordsMatch()
    {
        return this.passwordTextBox.Text.Equals(this.passwordConfirmationTextBox.Text);
    }

    private void onClosing(object? sender, FormClosingEventArgs e)
    {
        this.emailTextBox.LostFocus -= this.emailTextBox_FocusChanges;
    }

    private void emailTextBox_FocusChanges(object? sender, EventArgs e)
    {
        if (!this.isValidEmail(this.emailTextBox.Text))
        {
            MessageBox.Show(InvalidEmailAddress, InvalidEmail, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            this.emailTextBox.BackColor = Color.White;
        }
    }

    private bool isValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    #endregion
}