namespace HeartwoodTrees.Business.Notifications
{
    using HeartwoodTrees.Business.Asserts;

    /// <summary>
    /// Defines a class responsible for providing extended functionality to email addresses
    /// </summary>
    public static class EmailAddressExtensions
    {
        /// <summary>
        /// The full email address.
        /// </summary>
        /// <param name="emailAddress">
        /// The email address.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string FullEmailAddress(this IEmailAddress emailAddress)
        {
            ArgumentAssert.IsNotNull(emailAddress, "emailAddress");
            return string.IsNullOrWhiteSpace(emailAddress.Name) ? emailAddress.Address : string.Format("{0} <{1}>", emailAddress.Name, emailAddress.Address);
        }
    }
}
