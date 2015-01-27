// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotificationDetails.cs" company="Heartwood Trees Ltd Limited">
//   Copyright © heartwoodtreesltd.co.nz. All rights reserved.
// </copyright>
// <summary>
//   Defines the INotificationDetails type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HeartwoodTrees.Business.Notifications
{
    /// <summary>
    /// The i notification details.
    /// </summary>
    public interface IQueryDetails
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        EmailAddress Email { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        string Phone { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }
    }
}
