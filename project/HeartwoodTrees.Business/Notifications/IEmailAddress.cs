namespace HeartwoodTrees.Business.Notifications
{
    /// <summary>
    /// Defines an email address interface 
    /// </summary>
    public interface IEmailAddress
    {
        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        string Address { get; set; }
    }
}
