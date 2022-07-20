using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsSayiTahminOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int rastgeleSayi;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //her saniye çalışacak olan event
            //interval 1000ms (1 second) verdiğimiz için

            progressBar1.Value--;
            btnTahminEt.Text = "Tahmin Et (" + progressBar1.Value + ")";

           
            switch (progressBar1.Value)
            {
                case 50:
                    lblGicikEdenMesajlar.Text = "Kesin kaybedeceksin :)))";
                    break;
                case 40:
                    lblGicikEdenMesajlar.Text = "Sen kaybetmek için yarışıyosun";
                    break;
                case 30:
                    lblGicikEdenMesajlar.Text = "Senden olmayacak, sen git kod yaz...";
                    break;
                case 20:
                    lblGicikEdenMesajlar.Text = "Kaplumbağa daha hızlı";
                    break;
                case 10:
                    lblGicikEdenMesajlar.Text = "Eeee bitti yapamadın kiii asjkhaskjgfakj";
                    break;
                case 0:
                    lblBilgi.Text = "KAYBETTİİİİİN :D olmuyosa zorlama";
                    timer1.Stop();
                    btnTahminEt.Enabled = txtSayi.Enabled = false;
                    progressBar1.Value = 0;
                    break;
            }
            if (progressBar1.Value < 20)
            {
                Console.Beep(200, 2);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnTahminEt.Enabled = false;
            txtSayi.Enabled = false;
        }

        private void btnOyunuBaslat_Click(object sender, EventArgs e)
        {
            timer1.Start();
            btnTahminEt.Enabled = true;
            txtSayi.Enabled = true;

            Random rnd = new Random();
            rastgeleSayi = rnd.Next(1, 101);

            progressBar1.Value = 60;

            lblBilgi.Text = "";

            txtSayi.Text = "";
            btnTahminEt.Text = "Tahmin Et";

            

        }

        private void btnTahminEt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSayi.Text))
            {
                lblBilgi.Text = "Sayi girmeyi unuttun...";
            }
            else
            {
                int sayi = 0;
                try
                {
                    sayi = int.Parse(txtSayi.Text);

                    if (sayi < rastgeleSayi)
                    {
                        lblBilgi.Text = "Küçük sayi girdin.";
                    }
                    else if (sayi > rastgeleSayi)
                    {
                        lblBilgi.Text = "Büyük sayi girdin.";
                    }
                    else
                    {
                        lblBilgi.Text = "KAZANDIN.";
                        timer1.Stop();
                        btnTahminEt.Enabled = txtSayi.Enabled = false;

                        

                        

                        if(progressBar1.Value > 50)
                        {
                            lblBilgi.Text = "Helal fena değilsin";
                        }
                        else if (progressBar1.Value > 40)
                        {
                            lblBilgi.Text = "Yaaaaaniii";
                        }
                        else if (progressBar1.Value > 30)
                        {
                            lblBilgi.Text = "Bence kötüydün sence?";
                        }
                        else if (progressBar1.Value > 20)
                        {
                            lblBilgi.Text = "Oyun zor değil sen kötüsün";
                        }
                        else if (progressBar1.Value > 10)
                        {
                            lblBilgi.Text = "Ahahahahahah hiç bilmeseydin";
                        }
                        progressBar1.Value = 0;
                    }

                }
                catch (Exception)
                {
                    lblBilgi.Text = "Sayi girmeyi unuttun...";

                }
            }
        }

        


    }
}
