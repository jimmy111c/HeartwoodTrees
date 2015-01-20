// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigProvider.cs" company="Eyedentify Limited">
//   Copyright © eyedentify.co.nz. All rights reserved.
// </copyright>
// <summary>
//   The config provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HeartwoodTrees.Business
{
    using System;
    using System.Threading;

    /// <summary>
    /// The config provider.
    /// </summary>
    internal static class ConfigProvider
    {
        /// <summary>
        /// The max number of login try.
        /// </summary>
        public const int MaxFailedAccessAttemptsBeforeLockout = 3;

        /// <summary>
        /// The lockout duration.
        /// </summary>
        public static readonly TimeSpan DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(30);

        public static string GetConfigCountryPrefix()
        {
            string currentCulture = Thread.CurrentThread.CurrentUICulture.ToString();

            if (currentCulture.Equals("en-AU"))
            {
                return "AUS_";
            }
            else
            {
                return "NZ_";
            }
        }

        public static string GetEmailFooter()
        {
            string currentCulture = Thread.CurrentThread.CurrentUICulture.ToString();

            if (currentCulture.Equals("en-AU"))
            {
                return "The content of this e-mail (the \"Communication\") is confidential, may contain copyright information, and is for the use only of the intended recipient. This Communication should not be sent to other persons who are not registered users of Eyedentify. If this Communication is not intended for you, please notify the sender immediately by return e-mail, delete the Communication and return e-mail, and do not read, copy, retransmit or otherwise deal with it. Thank you.";
            }
            else
            {
                return "The content of this e-mail (the \"Communication\") is confidential, may contain copyright information, and is for the use only of the intended recipient. This Communication should not be sent to other persons who are not registered users of Eyedentify. If this Communication is not intended for you, please notify the sender immediately by return e-mail, delete the Communication and return e-mail, and do not read, copy, retransmit or otherwise deal with it. Nothing in this e-mail message constitutes a designation of an information system for the purposes of section 11(a) of the Electronic Transactions Act 2002 (New Zealand). Thank you.";
            }
        }
    }
}
