using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyDesk.Model;
using StudyDesk.View.SourceControls;

namespace StudyDesk.View
{
    public partial class SourceForm : Form
    {
        public SourceForm()
        {
            InitializeComponent();
        }

        public SourceForm(SourceType type)
        {
            this.InitializeComponent();
            this.handleType(type);
        }

        private void handleType(SourceType type)
        {
            switch (type)
            {
                case SourceType.Video:
                case SourceType.VideoLink:
                    this.addVideoControl();
                    break;
                case SourceType.Pdf:
                case SourceType.PdfLink:
                    this.addPdfControl();
                    break;
                default:
                    break;
            }
        }

        private void addVideoControl()
        {
            var videoControl = new VideoControl();
            videoControl.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(videoControl);
        }

        private void addPdfControl()
        {
            // // var pdfControl = new PdfControl();
            // pdfControl.Dock = DockStyle.Fill;
            // this.splitContainer1.Panel2.Controls.Add(pdfControl);
        }

        private void addImageControl()
        {
            var imageControl = new ImageControl();
            imageControl.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(imageControl);
        }
    }
}
