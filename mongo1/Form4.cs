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
using System.Text.RegularExpressions;

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

               
       
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(textBox7.Text);

                mail.From = new MailAddress(textBox1.Text);
                mail.To.Add(textBox3.Text);
               if(!string.IsNullOrEmpty(textBox8.Text))
                mail.To.Add(new MailAddress(textBox8.Text));
                mail.Subject = textBox4.Text;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = textBox5.Text;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                SmtpServer.Port = Convert.ToInt32(textBox6.Text);
                SmtpServer.Credentials = new System.Net.NetworkCredential(textBox1.Text, textBox2.Text);
               // SmtpServer.UseDefaultCredentials = true;
                SmtpServer.EnableSsl = true;
                mail.Attachments.Add(a);
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                //SmtpServer.Send (mail);
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                SmtpServer.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
               // String userstate = "Sending";
                SmtpServer.SendAsync(mail,SmtpServer); //userstate);
                
            //try{
            
            //SmtpServer.Send(mail);
            //  //  MessageBox.Show("mail Sending Completed");
            //MessageBox.Show("Mail Send Suceesfull");
            //      }
        
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());

            //}

        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show(string.Format("{0} send cmasla", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Error != null)
                MessageBox.Show(string.Format("{0} {1} send canceled", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
  
            else
                MessageBox.Show("Your mail has been Send", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            string email = textBox3.Text;

            System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (expr.IsMatch(email))
            {
                
            }
            else
            {
                MessageBox.Show("Enter Vali Email ID");
               
            }
        }

      
        }
      
        }
      

    
