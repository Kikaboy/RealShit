using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WinFormsApp_ViewPicture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FolderBrowserDialog.FileName = "";
            FolderBrowserDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {

                string fullPath = FolderBrowserDialog.FileName;
                label1.Text = fullPath.Substring(0, fullPath.LastIndexOf('\\'));
                string[] files = Directory.GetFiles(fullPath.Substring(0, fullPath.LastIndexOf('\\')));
                foreach (string file in files)
                {
                    listBox1.Items.Add(Path.GetFileName(file));
                }
                try
                {
                    pictureBox1.Image = Image.FromFile(FolderBrowserDialog.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не корректный файл. Выберите, пожалуйста, файл с расширением .png|.jpeg|.bmp|.gif","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            FolderBrowserDialog.Filter = "Images (*.png)|*.png|All files (*.*)|*.*";
            FolderBrowserDialog.Title = "Please select an image file.";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            FolderBrowserDialog.Filter = "Images (*.jpg)|*.jpg|All files (*.*)|*.*";
            FolderBrowserDialog.Title = "Please select an image file.";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            FolderBrowserDialog.Filter = "Images (*.bmp)|*.bmp|All files (*.*)|*.*";
            FolderBrowserDialog.Title = "Please select an image file.";
        }
    }
}
