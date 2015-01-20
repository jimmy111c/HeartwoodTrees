// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessValidationException.cs" company="Eyedentify Limited">
//   Copyright © eyedentify.co.nz. All rights reserved.
// </copyright>
// <summary>
//   Defines an exception thrown when a business validation failed.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HeartwoodTrees.Business
{
    using System;

    /// <summary>
    /// Defines an exception thrown when a business validation failed.
    /// </summary>
    [Serializable]
    public class BusinessValidationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessValidationException"/> class.
        /// </summary>
        public BusinessValidationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessValidationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public BusinessValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessValidationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="inner">
        /// The inner.
        /// </param>
        public BusinessValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
     }
}
