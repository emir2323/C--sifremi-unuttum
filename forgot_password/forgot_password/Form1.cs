using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forgot_password
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {


        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgln = new sqlbaglantisi();
            SqlCommand komut = new SqlCommand("Select * From forgotpassword Where kullanici_adi='" + textBox1.Text.ToString() + "'and eposta='" + textBox2.Text.ToString() + "'", bgln.baglanti());

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                try
                {
                    if (bgln.baglanti().State == ConnectionState.Closed)
                    {

                        bgln.baglanti().Open();
                    }

                    SmtpClient smtpserver = new SmtpClient();
                    MailMessage mail = new MailMessage();
                    String tarih = DateTime.Now.ToLongDateString();
                    String mailadresin = ("yemir6924@gmail.com");
                    String şifre = ("mnjwiacmzjmyshxj");
                    String smtpsrvr = "smtp.gmail.com";
                    String kime = (oku["eposta"].ToString());
                    String konu = ("Şifre hatırlatma Maili");
                    String yaz = ("SSayın," + oku["ad_soyad"].ToString() + "\n" + "Bizden" + tarih + "Tarihinde Bizden Şifre Hatırlatma talebinde bulundunuz" + "\n" + "Parolanız:" + oku["şifre"].ToString() + "\nİyi Günler");

                    smtpserver.Credentials = new NetworkCredential(mailadresin, şifre);
                    smtpserver.Port = 587;
                    smtpserver.Host = smtpsrvr;
                    smtpserver.EnableSsl = true;
                    mail.From = new MailAddress(mailadresin);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body = yaz;
                    smtpserver.Send(mail);
                    DialogResult bilgi = new DialogResult();
                    bilgi = MessageBox.Show("Girmiş olduğunuz bilgiler uyuşuyor.Şifreniz mail adresinize gönderilmiştir");
                    this.Hide();


                }
                catch (Exception Hata)
                {
                    MessageBox.Show("Mail gönderme hatası", Hata.Message);
                }





            }
        }


      

    }
}

