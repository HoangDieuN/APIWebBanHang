using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public  class EmailHelper
    {
        private static string FromEmailAddress = System.Configuration.ConfigurationManager.AppSettings["Email"].ToString();
        private static string FromEmailPassword = System.Configuration.ConfigurationManager.AppSettings["Password"].ToString();
        public static bool IsValidEmail(string emailAddress)
        {
            try
            {
                var addr = new MailAddress(emailAddress);
                return addr.Address == emailAddress;
            }
            catch
            {
                return false;
            }
        }
        public static void SendEmail(string Subject, string Body, string ToEmailAdress, List<string> attachments= null)
        {
            var list = new List<string>
            {
                ToEmailAdress
            };
            SendEmail(Subject, Body, list, attachments);
        }
        public static void SendEmail(string Subject, string Body, List<string> ToEmailAdress, List<string> attachments = null)
        {
            try
            {
                var fromAddress = new MailAddress(FromEmailAddress, System.Configuration.ConfigurationManager.AppSettings["DisplayNameEmail"].ToString());
                var smtp = new SmtpClient
                {

                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, FromEmailPassword)
                };
                var message = new MailMessage();
                var toAddress = new List<MailAddress>();
                message.From = fromAddress;
                foreach (var item in ToEmailAdress)
                {
                    if (IsValidEmail(item))
                    {
                        message.To.Add(item);
                    }
                }
                message.Subject = Subject;
                message.Body = Body;

                foreach (var item in attachments)
                {
                    if (!String.IsNullOrEmpty(item))
                    {
                        Attachment attachment;
                        attachment = new Attachment(item);
                        message.Attachments.Add(attachment);
                    }
                }

                smtp.Send(message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SendEmail error: {ex.Message}");
            }
        }
    }
}

