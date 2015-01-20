// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmtpConfig.cs" company="Eyedentify Limited">
//   Copyright © eyedentify.co.nz. All rights reserved.
// </copyright>
// <summary>
//   The smtp config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HeartwoodTrees.Business.Notifications
{
    /// <summary>
    /// The SMTP config.
    /// </summary>
    public class SmtpConfig
    {
        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether enable ssl.
        /// </summary>
        public bool EnableSsl { get; set; }
    }
}
