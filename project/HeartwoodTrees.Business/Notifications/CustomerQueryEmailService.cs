// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerQueryEmailService.cs" company="Heartwood Trees Ltd Limited">
//   Copyright © heartwoodtreesltd.co.nz. All rights reserved.
// </copyright>
// <summary>
//   Defines the CustomerQueryEmailService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HeartwoodTrees.Business.Notifications
{
    using System;

    using HeartwoodTrees.Business;

    /// <summary>
    /// The reset password email notification service.
    /// </summary>
    internal class CustomerQueryEmailService
    {
        /// <summary>
        /// The send notification.
        /// </summary>
        /// <param name="emailAddress">
        /// The email Address.
        /// </param>
        /// <param name="model">
        /// The model.
        /// </param>
        public void SendNotification(EmailAddress emailAddress, object model)
        {
            string configCountryPrefix = ConfigProvider.GetConfigCountryPrefix();
            var from = new EmailAddress(ConfigReader.ReadConfigSetting(configCountryPrefix+ "SupportEmailAddress"));
            string smtpServer = ConfigReader.ReadConfigSetting(configCountryPrefix + "SMTPServer");

            bool enableSSL = false;
            if (smtpServer.Contains("gmail"))
            {
                enableSSL = true; 
            }

            var notificationService = new EmailNotificationService(
                @from,
                new SmtpConfig
                    {
                        Host = smtpServer,
                        UserName = ConfigReader.ReadConfigSetting(configCountryPrefix + "SupportEmailAddress"),
                        Password = ConfigReader.ReadConfigSetting(configCountryPrefix + "SupportEmailPassword"),
                        Port = 587,
                        EnableSsl = enableSSL
                    });

            string DomainNameForEmails = ConfigReader.ReadConfigSetting(configCountryPrefix + "DomainName");

            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin/Notifications/Templates/CustomerEnquiry.txt");
            var fileNotificationContentService = new FileNotificationContentService(path);
            notificationService.SendNotification(emailAddress, DomainNameForEmails + " - New User", fileNotificationContentService, model, true);
        }
    }
}
