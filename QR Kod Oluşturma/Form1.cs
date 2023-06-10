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
                MessageBox.Show("QR kodu oluşturabilmek için lütfen önce URL adresi, E-posta adresi, Telefon numarası giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                QRCodeEncoder QRCode = new QRCodeEncoder();
                pictureBox1.Image = QRCode.Encode(textBox1.Text);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Resmi kaydetme işlemi
            PictureBox picture = new PictureBox();
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "JPG Dosyası | *.jpg | PNG Dosyası | *.png";
            //saveFileDialog.DefaultExt = "jpg";
            saveFileDialog.Title = "QR Kodu Kaydet";

            if (textBox1.Text == "")
            {
                MessageBox.Show("QR kodu kaydedilemedi! Lütfen boş bırakmayınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string dosyaYolu = saveFileDialog.FileName;
                    picture.Image.Save(dosyaYolu);
                    label1.Visible = true;
                    label1.Text = "QR Kodu seçilen dosya yoluna başarıyla kaydedildi!\n" + dosyaYolu;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Bisque;

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;

        }
    }
}
