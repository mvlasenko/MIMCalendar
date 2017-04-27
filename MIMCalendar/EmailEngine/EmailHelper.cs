using System;
using System.Net.Mail;
using System.Security.Policy;
using System.Web;
using MIMCalendar.Helpers;
using MIMCalendar.Models;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace MIMCalendar.EmailEngine
{
    public static class EmailHelper
    {
        //public static string GetTemplateBody(Training training, string bodyTemplate)
        //{
        //    string body = bodyTemplate.Replace("@", "@Model.").Replace("Model.Model.", "Model.").Replace("@Model.Recipient.", "@@Recipient.");

        //    body = Engine.Razor.RunCompile(body, Guid.NewGuid().ToString(), typeof(Training), training);

        //    body = body.Replace("@@Recipient.", "@Recipient.");

        //    return body;
        //}

        public static string GetEmailBody(ApplicationUser recipient, string bodyTemplate, string subject, string logoTop = null)
        {
            string body = bodyTemplate.Replace("@Recipient.", "@Model.").Replace("Model.Model.", "Model.");

            body = Engine.Razor.RunCompile(body, Guid.NewGuid().ToString(), typeof(ApplicationUser), recipient);

            return body;

            //EmailLayoutViewModel layoutModel = new EmailLayoutViewModel();
            //layoutModel.Subject = subject;
            //layoutModel.Body = body;
            //layoutModel.Year = DateTime.Now.Year.ToString();
            //layoutModel.Copyright = Display.Copyright;
            //layoutModel.ContactUs = Display.ContactUs;
            //layoutModel.ContactUsLink = Display.ContactUsLink;
            //layoutModel.CompanyAddress = Display.CompanyAddress;
            //layoutModel.Signature = Display.Signature;
            //layoutModel.GoLearning = Display.GoLearning;
            //layoutModel.GoLearningLink = Display.GoLearningLink;
            //layoutModel.LogoTop = string.IsNullOrEmpty(logoTop) ? HttpContext.Current.Request.ApplicationPath + "/Images/logo_top.png" : string.Format("cid:{0}", logoTop);

            //string html = Engine.Razor.RunCompile(File.ReadAllText(HttpContext.Current.Server.MapPath("~/Views/Shared/Email_layout.txt")), Guid.NewGuid().ToString(), typeof(EmailLayoutViewModel), layoutModel);

            //return html;
        }

        public static string GetTextBody(ApplicationUser recipient, string bodyTemplate, string subject)
        {
            string body = bodyTemplate.Replace("@Recipient.", "@Model.").Replace("Model.Model.", "Model.");

            body = Engine.Razor.RunCompile(body, Guid.NewGuid().ToString(), typeof(ApplicationUser), recipient).HtmlToText();

            return body;
        }

        public static void SendEmail(string fromEmail, ApplicationUser recipient, string bodyTemplate, string subject)
        {
            try
            {
                //replace body tokens
                var config = new TemplateServiceConfiguration();
                var service = RazorEngineService.Create(config);
                Engine.Razor = service;

                //send email
                SmtpClient client = new SmtpClient();

                MailAddress from = new MailAddress(fromEmail);
                MailAddress to = new MailAddress(recipient.Email, recipient.FirstName + " " + recipient.LastName, System.Text.Encoding.UTF8);

                MailMessage message = new MailMessage(from, to);
                message.Subject = subject;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;

                var logoTop = new LinkedResource(HttpContext.Current.Server.MapPath("~/Images/logo_top.png"));
                logoTop.ContentId = Guid.NewGuid().ToString();

                message.Body = GetTextBody(recipient, bodyTemplate, subject);

                string body = GetEmailBody(recipient, bodyTemplate, subject, logoTop.ContentId);

                var view = AlternateView.CreateAlternateViewFromString(body, System.Text.Encoding.UTF8, "text/html");
                view.LinkedResources.Add(logoTop);
                message.AlternateViews.Add(view);

                client.Send(message);
            }
            catch (Exception ex)
            {
                //todo: configure logging for odata application
                //SiteLogger.Error("Exception occurred in {2}: {0}\r\n{1}", LoggingCategory.General, ex.Message, ex.StackTrace, typeof(EmailHelper).Name);
                //throw;
            }
        }

        public static void SendConfirmEmail(ApplicationUser user, string callbackUrl)
        {
            string body = "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>";
            SendEmail("admin@mim.kiev.ua", user, body, "Confirm your account");

        }

    }
}