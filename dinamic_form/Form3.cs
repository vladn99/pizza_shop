using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace dinamic_form
{
    public partial class Form3 : Form
    {
        public string chek { get; set; }
        public string adres { get; set; }

        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = chek;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = $@"\{adres}.txt";
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
                path = fd.SelectedPath + path;
            try
            {
                FileStream writer = new FileStream(path, FileMode.OpenOrCreate);
                byte[] arr = Encoding.Default.GetBytes(textBox1.Text);
                writer.Write(arr, 0, textBox1.Text.Length);
                writer.Close();
                MessageBox.Show("Чек сохранен");
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }
    }
}
