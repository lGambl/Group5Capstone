using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace StudyDesk.View
{
    /// <summary>
    /// The main page form.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainPageForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageForm"/> class.
        /// </summary>
        public MainPageForm()
        {
            this.InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void addButton_Click(object sender, EventArgs e)
        {

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
            
        }
    }
}
