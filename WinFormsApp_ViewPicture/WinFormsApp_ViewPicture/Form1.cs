using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp_ViewPicture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;
            this.FBD.FileName = "";
            //this.FBD.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                string fullPath = FBD.FileName;
                label1.Text = fullPath.Substring(0, fullPath.LastIndexOf('\\'));
                string[] files = Directory.GetFiles(fullPath.Substring(0, fullPath.LastIndexOf('\\')));
                foreach (string file in files)
                {
                    listBox1.Items.Add(Path.GetFileName(file));
                    var path = Directory.GetParent(file).FullName;
                    listBox1.SelectedValueChanged += (o, ea) =>
                    {
                        pictureBox1.Image = Image.FromFile(Path.Combine(path,(string)((ListBox)o).SelectedItem));
                    };
                }

                try
                {
                    pictureBox1.Image = Image.FromFile(FBD.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не корректный файл. Выберите, пожалуйста, файл с расширением .png|.jpeg|.bmp|.gif","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            FBD.Filter = "Images (*.png)|*.png|All files (*.*)|*.*";
            FBD.Title = "Please select an image file.";
            listBox1.Items.Clear();
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            FBD.Filter = "Images (*.jpg)|*.jpg|All files (*.*)|*.*";
            FBD.Title = "Please select an image file.";
            listBox1.Items.Clear();

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            FBD.Filter = "Images (*.bmp)|*.bmp|All files (*.*)|*.*";
            FBD.Title = "Please select an image file.";
            listBox1.Items.Clear();

        }
    }
}
