// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileNotificationContentService.cs" company="Heartwood Trees Ltd Limited">
//  Copyright © heartwoodtreesltd.co.nz. All rights reserved.
// </copyright>
// <summary>
//   Defines the FileNotificationContentService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HeartwoodTrees.Business.Notifications
{
    using System.IO;

    /// <summary>
    /// The simple notification content service.
    /// </summary>
    public class FileNotificationContentService
    {
        /// <summary>
        /// The template name.
        /// </summary>
        private readonly string templateName;

        /// <summary>
        /// The template content.
        /// </summary>
        private string templateContent;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileNotificationContentService"/> class.
        /// </summary>
        /// <param name="templateName">
        /// The template name.
        /// </param>
        public FileNotificationContentService(string templateName)
        {
            this.templateName = templateName;
        }

        /// <summary>
        /// The get content.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetContent(object model)
        {
            var template = this.GetTemplateContent();

            var content = Nustache.Core.Render.StringToString(template, model);
            return content;
        }

        /// <summary>
        /// The get template content.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected string GetTemplateContent()
        {
            if (this.templateContent == null)
            {
                this.templateContent = ReadFromTemplateFile(this.templateName);
            }

            return this.templateContent;
        }

        /// <summary>
        /// The read from template file.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected static string ReadFromTemplateFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

    }
}
