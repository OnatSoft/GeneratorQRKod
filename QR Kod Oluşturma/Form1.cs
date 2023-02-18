using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;

namespace QR_Kod_Oluşturma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("QR kod oluşturabilmek için lütfen önce URL adresi, E-posta adresi, Telefon numarası giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                QRCodeEncoder QRCode = new QRCodeEncoder();
                pictureBox1.Image = QRCode.Encode(textBox1.Text);
            }

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.Filter = "JPeg Dosyası|*.jpg|PNG Dosyası|*.png|";
            //saveFileDialog1.Title = "QR Kod Kaydet";
            //saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                SaveFileDialog kaydet = new SaveFileDialog();
                kaydet.Filter = "JPEG Dosyası|*.jpg | PNG Dosyası | *.png";
                kaydet.Title = "QR Kodu Farklı Kaydet";
                kaydet.OverwritePrompt = true;
                kaydet.CreatePrompt = true;
                kaydet.ShowDialog();

                if (kaydet.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = saveFileDialog1.FileName;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.BackColor = Color.Bisque;
        }
    }
}
