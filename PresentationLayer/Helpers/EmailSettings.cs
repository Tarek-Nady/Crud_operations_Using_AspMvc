using DataAccessLayer.Entities;
using System.Net;
using System.Net.Mail;

namespace PresentationLayer.Helpers
{
    public static class EmailSettings
    {

        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com",587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("faisalalshreff7@gmail.com", "ylskbwgvedndohyj");
            client.Send("faisalalshreff7@gmail.com", email.To, email.Subject, email.Body);
        }

    }
}
