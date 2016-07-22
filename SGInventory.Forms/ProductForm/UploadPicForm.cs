using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SGInventory.Helpers;
using System.Configuration;
using System.IO;

namespace SGInventory.ProductForm
{
    public partial class UploadPicForm : Form
    {
        public event EventHandler OnClosing;

        public string PictureName{ get; set; }

        public UploadPicForm()
        {            
            InitializeComponent();
            
        }

        private void browsePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog =  openFileDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                rotateToolStripMenuItem.Enabled = true;
                var image = Image.FromFile(openFileDialog1.FileName);           
                picBoxStock.Image = image;                             
                PictureName = openFileDialog1.FileName;
                if (OnClosing != null)
                {
                    OnClosing(sender, e);
                }
            }
        }
    
        private void UploadPicForm_Load(object sender, EventArgs e)
        {
            rotateToolStripMenuItem.Enabled = false;
            if (string.IsNullOrEmpty(PictureName)) return;
            rotateToolStripMenuItem.Enabled = true;                
            var drive = SgiHelper.GetRootDirectory();
            var uploadedPicDestination = Path.Combine(drive, PictureName);

            if (!File.Exists(uploadedPicDestination))
            {
                MessageBox.Show(string.Format("Unable to find image located in {0}", uploadedPicDestination));
                return;
            }

            SgiHelper.LoadFromFileSystemStorage(picBoxStock,uploadedPicDestination);
            PictureName = uploadedPicDestination;
        }

        private void clockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rotate(RotateFlipType.Rotate90FlipNone);
        }

        private void counterClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rotate(RotateFlipType.Rotate270FlipNone);
        }

        private void Rotate(RotateFlipType flipType)
        {
            var image = picBoxStock.Image;
            image.RotateFlip(flipType);
            picBoxStock.Image = image;
        }

    }
}
