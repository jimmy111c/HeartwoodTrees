namespace HeartwoodTrees.Business.Notifications
{
    public class EmailAddress
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAddress"/> class.
        /// </summary>
        public EmailAddress()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAddress"/> class.
        /// </summary>
        /// <param name="address">
        /// The address.
        /// </param>
        public EmailAddress(string address)
        {
            this.Address = address;
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The full email address.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string FullEmailAddress()
        {
            return string.IsNullOrWhiteSpace(this.Name) ? this.Address : string.Format("{0} <{1}>", this.Name, this.Address);
        }
    }
}
