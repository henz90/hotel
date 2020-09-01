using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using System.Diagnostics;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System.Collections;
using System.Collections.Generic;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HotelProject.Services
{
    public class EmailSender 
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public void SendEmailAsync(string email, string subject, string message)
        {
             Execute("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",
                     subject, message, email);
        }

        public void Execute(string apiKey, string subject, string message, string email)
        {
            Configuration.Default.AddApiKey("api-key", apiKey);
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("api-key", "Bearer");
            // Configure API key authorization: partner-key
            Configuration.Default.AddApiKey("partner-key", apiKey);
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("partner-key", "Bearer");

            var apiInstance = new SMTPApi();
            //var sendSmtpEmail = new SendSmtpEmail(); // SendSmtpEmail | Values to send a transactional email
            var sendSmtpEmail = new SendSmtpEmail(sender:new SendSmtpEmailSender("noreply@libraryproject.ipd21.com", "No-Reply"),
                                                    to: new List<SendSmtpEmailTo>() { new SendSmtpEmailTo(email,"Verify")},
                                                    htmlContent:message,subject:subject);
            // {              
            //     TextContent="hi",
            //     HtmlContent = message,
            //     Subject = subject
            // };
            try
            {
                // Send a transactional email
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SMTPApi.SendTransacEmail: " + e.Message);
            }

            //return true;
        }
    }
}
