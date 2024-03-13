﻿using Microsoft.IdentityModel.Tokens;
using StudyDesk.Controller;
using StudyDesk.Model;

namespace StudyDesk.View;

/// <summary>
///     The main page form.
/// </summary>
/// <seealso cref="System.Windows.Forms.Form" />
public partial class MainPageForm : Form
{
    #region Data members

    private const string? NotImplementedYet = "Not implemented yet.";
    private const string? LogoutFailed = "Logout failed";
    private const string? DeletionFailed = "Deletion Failed";

    private const string? DeletionFailedPleaseTryAgainOrContactAdmin =
        "Deletion Failed. Please try again or contact admin.";

    private const string? PleaseEnterATagToSearch = "Please enter a tag to search.";
    private const string? InvalidSearch = "Invalid Search";

    private const string? AreYouSureYouWantToDeleteThisSource = "Are you sure you want to delete this source?";
    private const string? DeleteSource = "Delete Source";
    private const string? EnterTagToSearch = "Enter tag to search...";

    private readonly MainPageController controller;

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="MainPageForm" /> class.
    /// </summary>
    public MainPageForm(AuthService auth)
    {
        this.InitializeComponent();
        StartPosition = FormStartPosition.CenterScreen;
        this.controller = new MainPageController(auth);
        this.loadSources();
    }

    #endregion

    #region Methods

    private void loadSources()
    {
        this.indexListView.Items.Clear();
        foreach (var source in this.controller.Sources)
        {
            var item = new ListViewItem(source.Title);
            this.indexListView.Items.Add(item);
        }
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        var addSourceForm = new AddSourceForm(this.controller.AuthService);
        addSourceForm.ShowDialog();
        this.loadSources();
    }

    private void indexListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.indexListView.SelectedItems.Count > 0)
        {
            this.deleteButton.Enabled = true;
        }
        else
        {
            this.deleteButton.Enabled = false;
        }
    }

    private void indexListView_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        var source = this.controller.Sources[this.indexListView.SelectedIndices[0]];
        var sourceForm = new SourceForm(source);
        sourceForm.ShowDialog();
    }

    private void logoutButton_Click(object sender, EventArgs e)
    {
        if (this.controller.Logout())
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            loginForm.Closed += (_, _) => Close();
            Hide();
        }

        else
        {
            MessageBox.Show(LogoutFailed, LogoutFailed, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void deleteButton_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show(AreYouSureYouWantToDeleteThisSource, DeleteSource, MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            if (this.controller.DeleteSource(this.indexListView.SelectedItems[0].ToString()).Result)
            {
                this.loadSources();
            }
            else
            {
                MessageBox.Show(DeletionFailedPleaseTryAgainOrContactAdmin, DeletionFailed, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }

    private void resetSourcesButton_Click(object sender, EventArgs e)
    {
        this.controller.ResetUserSources();
        this.loadSources();
    }

    private void searchNoteTagButton_Click(object sender, EventArgs e)
    {
        this.indexListView.Items.Clear();

        if (!this.searchNoteTagTextBox.Text.IsNullOrEmpty() &&
            this.searchNoteTagTextBox.Text != EnterTagToSearch)
        {
            foreach (var currSource in this.controller.getSourcesWithMatchingNoteTags(this.searchNoteTagTextBox.Text))
            {
                this.indexListView.Items.Add(currSource.Title);
            }

            this.searchNoteTagTextBox.Text = EnterTagToSearch;
            this.searchNoteTagTextBox.ForeColor = Color.Gray;
        }
        else
        {
            MessageBox.Show(PleaseEnterATagToSearch, InvalidSearch, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            this.loadSources();
        }

    }

    private void searchNoteTagTextBox_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(this.searchNoteTagTextBox.Text))
        {
            this.searchNoteTagTextBox.Text = EnterTagToSearch;
            this.searchNoteTagTextBox.ForeColor = Color.Gray;
        }
    }

    private void searchNoteTagTextBox_Enter(object sender, EventArgs e)
    {
        if (this.searchNoteTagTextBox.Text == EnterTagToSearch)
        {
            this.searchNoteTagTextBox.Text = string.Empty;
            this.searchNoteTagTextBox.ForeColor = Color.Black;
        }
    }

    #endregion
}