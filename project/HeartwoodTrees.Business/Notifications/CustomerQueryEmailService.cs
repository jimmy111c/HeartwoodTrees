// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerQueryEmailService.cs" company="">
//   
// </copyright>
// <summary>
//   The reset password email notification service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HeartwoodTrees.Business.Notifications
{
    using System;

    using FluentValidation;

    using HeartwoodTrees.Business.Asserts;
    using HeartwoodTrees.Business.Notifications.Validation;

    /// <summary>
    /// The reset password email notification service.
    /// </summary>
    public class CustomerQueryEmailService
    {
        /// <summary>
        /// The send notification.
        /// </summary>
        /// <param name="details">
        /// The query Details.
        /// </param>
        public void SendNotification(IQueryDetails details)
        {
            ArgumentAssert.IsNotNull(details, "details");

            var validator = new QueryDetailsValidation();
            validator.ValidateAndThrow(details);

            try
            {
                var from = new EmailAddress(ConfigReader.ReadConfigSetting("ContactEmailAddress"));
                var smtpServer = ConfigReader.ReadConfigSetting("SMTPServer");

                var enableSsl = smtpServer.Contains("gmail");

                var notificationService = new EmailNotificationService(
                    @from,
                    new SmtpConfig
                        {
                            Host = smtpServer,
                            UserName = ConfigReader.ReadConfigSetting("ContactEmailAddress"),
                            Password = ConfigReader.ReadConfigSetting("ContactEmailPassword"),
                            Port = 587,
                            EnableSsl = enableSsl
                        });

                var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin/Notifications/Templates/CustomerEnquiry.txt");
                var fileNotificationContentService = new FileNotificationContentService(path);
                var model = new { details.Name, Query = details.Message, Email = details.Email.Address, details.Phone };
                notificationService.SendNotification(details.Email, string.Format("New Customer Query from {0}", details.Name), fileNotificationContentService, model);
            }
            catch (Exception)
            {
                throw new Exception("Your query failed to send, please try again. If the problem persists contact us at heartwoodtreesltd@gmail.com");
            }
        }
    }
}
