using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BestPhonebookDesktopApp.DAL;
using BestPhonebookDesktopApp.Model;
using BestPhonebookDesktopApp.ViewModel;

namespace BestPhonebookDesktopApp
{

    /// <summary>
    ///   The phonebook form code.
    /// </summary>
    public partial class PhonebookForm : Form
    {

        /// <summary>
        ///   Initializes a new instance of the <see cref="PhonebookForm" /> class.
        /// </summary>
        public PhonebookForm()
        {
            InitializeComponent();
            //this.addPhonebookEntriesToListView();
        }

        private void addPhonebookEntriesToListView()
        {
            foreach (PhonebookEntry currEntry in PhonebookViewModel.GetAllEntries())
            {
                this.phonebookEntriesListView.Items.Add(currEntry.Name + ": " + currEntry.PhoneNumber);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            this.nameLabel.Text = PhonebookViewModel.GetEntryByName(this.SearchTextBox.Text).Name;
            this.phoneNumberLabel.Text = PhonebookViewModel.GetEntryByName(this.SearchTextBox.Text).PhoneNumber;
        }
    }
}
