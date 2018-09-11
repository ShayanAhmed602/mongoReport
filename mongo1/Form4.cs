using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver.Builders;
using Microsoft.Reporting.WinForms;
using System.Net;
using System.Net.Mail;


namespace mongo1
{
    public partial class Form4 : Form
    {
        public byte[] ac;
        public Form4()
        {
            InitializeComponent();


        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //taken pdf from form 3 butoon of Email
            //File as Attachment
            System.IO.MemoryStream s = new System.IO.MemoryStream(Form3.bytes);
            s.Seek(0, System.IO.SeekOrigin.Begin);
            Attachment a = new Attachment(s, "Report.pdf");


            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(textBox7.Text);

                mail.From = new MailAddress(textBox1.Text);
                mail.To.Add(textBox3.Text);
              //  mail.To.Add(textBox8.Text); cc
                mail.Subject = textBox4.Text;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = textBox5.Text;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                SmtpServer.Port = Convert.ToInt32(textBox6.Text);
                SmtpServer.Credentials = new System.Net.NetworkCredential(textBox1.Text, textBox2.Text);
                SmtpServer.EnableSsl = true;
                mail.Attachments.Add(a);
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                SmtpServer.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                string UserState = "Sending...";
                SmtpServer.Send(mail);
               MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private static void SendCompletedCallback(object sender,AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show(string.Format("{0} send canceled", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(e.Error !=null)
                MessageBox.Show(string.Format("{0} {1} send canceled", e.UserState,e.Error ), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Your maiol has been Send","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        
        
        
        
        
        
        }
      

      

      
        
    }
}