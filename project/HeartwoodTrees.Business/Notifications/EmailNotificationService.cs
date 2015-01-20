// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailNotificationService.cs" company="Heartwood Trees Ltd Limited">
//   Copyright © heartwoodtreesltd.co.nz. All rights reserved.
// </copyright>
// <summary>
//   Defines the EmailNotificationService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HeartwoodTrees.Business.Notifications
{
    using System;
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
        public void SendNotification(EmailAddress toAddress, string subject, string message, bool sendCopy)
        {
            ArgumentAssert.IsNotNull(toAddress, "toAddress");
            ArgumentAssert.IsNotNullOrEmpty(subject, "subject");
            ArgumentAssert.IsNotNullOrEmpty(message, "message");

            var mm = new MailMessage(this.fromAddress.FullEmailAddress(), toAddress.FullEmailAddress(), subject, message) { IsBodyHtml = true };

            if (sendCopy)
            {
                mm.Bcc.Add(new MailAddress(ConfigReader.ReadConfigSetting(ConfigProvider.GetConfigCountryPrefix() + "ErrorEmailAddress")));
            }

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
        /// <param name="notificationContentService">
        /// The notification content service.
        /// </param>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <param name="sendCopy">
        /// Sends a copy of the email to eyedentify admin.
        /// </param>
        public void SendNotification(EmailAddress toAddress, string subject, FileNotificationContentService fileNotificationContentService, object model, bool sendCopy)
        {
            ArgumentAssert.IsNotNull(fileNotificationContentService, "fileNotificationContentService");
            this.SendNotification(toAddress, subject, fileNotificationContentService.GetContent(model), sendCopy);
        }
    }
}
