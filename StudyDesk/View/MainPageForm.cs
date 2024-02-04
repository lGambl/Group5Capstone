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
    public partial class MainPageForm : Form
    {
        public MainPageForm()
        {
            this.InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.indexListView.Items.Add("dummyItem");
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
