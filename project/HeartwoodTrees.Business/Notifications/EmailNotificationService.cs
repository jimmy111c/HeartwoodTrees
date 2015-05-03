// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailNotificationService.cs" company="Heartwood Trees Limited">
//   Copyright © heartwoodtressltd.co.nz.  All rights reserved.
// </copyright>
// <summary>
//   Defines the EmailNotificationService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HeartwoodTrees.Business.Notifications
{
    using System.Net;
    using System.Net.Mail;

    using HeartwoodTrees.Business.Asserts;

    /// <summary>
    /// The email notification service.
    /// </summary>
    public class EmailNotificationService
    {
        /// <summary>
        /// The from address.
        /// </summary>
        private readonly EmailAddress fromAddress;

        /// <summary>
        /// The smtp client.
        /// </summary>
        private readonly SmtpClient smtpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailNotificationService"/> class.
        /// </summary>
        /// <param name="fromAddress">
        /// The from address.
        /// </param>
        /// <param name="config">
        /// The config.
        /// </param>
        public EmailNotificationService(EmailAddress fromAddress, SmtpConfig config)
        {
            ArgumentAssert.IsNotNull(fromAddress, "fromAddress");
            ArgumentAssert.IsNotNull(config, "config");

            this.fromAddress = fromAddress;
            this.smtpClient = new SmtpClient(config.Host, config.Port)
                                  {
                                      Credentials = new NetworkCredential(config.UserName, config.Password),
                                      EnableSsl = config.EnableSsl
                                  };
        }

        /// <summary>
        /// The send notification.
        /// </summary>
        /// <param name="toAddress">
        /// The to Address.
        /// </param>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public void SendNotification(EmailAddress toAddress, string subject, string message)
        {
            ArgumentAssert.IsNotNull(toAddress, "toAddress");
            ArgumentAssert.IsNotNullOrEmpty(subject, "subject");
            ArgumentAssert.IsNotNullOrEmpty(message, "message");

            var mm = new MailMessage(this.fromAddress.FullEmailAddress(), toAddress.FullEmailAddress(), subject, message) { IsBodyHtml = true };

            this.smtpClient.Send(mm);
        }

        /// <summary>
        /// The send notification.
        /// </summary>
        /// <param name="toAddress">
        /// The to address.
        /// </param>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="fileNotificationContentService">
        /// The file Notification Content Service.
        /// </param>
        /// <param name="model">
        /// The model.
        /// </param>
        public void SendNotification(EmailAddress toAddress, string subject, FileNotificationContentService fileNotificationContentService, object model)
        {
            ArgumentAssert.IsNotNull(fileNotificationContentService, "fileNotificationContentService");
            this.SendNotification(toAddress, subject, fileNotificationContentService.GetContent(model));
        }
    }
}
