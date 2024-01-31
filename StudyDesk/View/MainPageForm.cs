using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyDesk.View
{
    public partial class MainPageForm : Form
    {
        public MainPageForm()
        {
            this.InitializeComponent();
            this.preloadDummyInfo();
        }

        private void preloadDummyInfo()
        {
            //this.pdfViewer1.LoadDocument("../../../Resources/dummyTextFile.txt");
            this.pdfViewer1.LoadDocument("../../../Resources/dummyPdf.pdf");
            this.pictureBox.Image = Image.FromFile("../../../Resources/dummyImage.jpg");
            this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void MainPageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
