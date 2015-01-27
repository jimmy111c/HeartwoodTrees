namespace HeartwoodTrees.Business.Notifications.Validation
{
    using FluentValidation;

    /// <summary>
    /// Defines a validator for the <see cref="IEmailAddress"/> type
    /// </summary>
    public class EmailAddressValidator : AbstractValidator<IEmailAddress>
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EmailAddressValidator"/> class.
        /// </summary>
        public EmailAddressValidator()
        {
            this.RuleFor(e => e.Address).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().Length(1, 255).EmailAddress().WithMessage("Invalid email address");

            this.RuleFor(e => e.FullEmailAddress()).Cascade(CascadeMode.StopOnFirstFailure).Length(1, 400).WithName("Email Address");
        }
    }
}
