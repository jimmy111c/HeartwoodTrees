// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigReader.cs" company="Eyedentify Limited">
//   Copyright © eyedentify.co.nz. All rights reserved.
// </copyright>
// <summary>
//   Defines the ConfigReader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HeartwoodTrees.Business.Notifications
{
    using System.Configuration;

    /// <summary>
    /// The config reader.
    /// </summary>
    internal class ConfigReader
    {
        /// <summary>
        /// The read config setting.
        /// </summary>
        /// <param name="setting">
        /// The setting.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        internal static string ReadConfigSetting(string setting)
        {
            var settings = new AppSettingsReader();
            var settingValue = (string)settings.GetValue(setting.ToString(), typeof(string));
            return settingValue;
        }
    }
}
