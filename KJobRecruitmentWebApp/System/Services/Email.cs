using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace KJobRecruitmentWebApp.System.Services
{
    static class Email
    {

        private static string apiKey = "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";
        private static SendGridClient client = new SendGridClient(apiKey);

        public static async void SendHtmlEmail(string sendToEmail, string sendToName, string subject, string content) {

            SendGridMessage msg = new SendGridMessage()
            {
                From = new EmailAddress("kjobrecruitment@gacdevelopment", "KJob Recruitment"),
                Subject = subject,
                //  PlainTextContent = "Hello, Email!",
                HtmlContent = content
            };

            msg.AddTo(new EmailAddress(sendToEmail, "Test User"));
            var response = await client.SendEmailAsync(msg);

        }
    }
}
