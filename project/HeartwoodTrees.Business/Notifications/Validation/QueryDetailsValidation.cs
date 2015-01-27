namespace HeartwoodTrees.Business.Notifications.Validation
{
    using FluentValidation;

    public class QueryDetailsValidation : AbstractValidator<IQueryDetails>
    {
        public QueryDetailsValidation()
        {
            this.RuleFor(a => a.Email).NotNull().SetValidator(new EmailAddressValidator()).WithMessage("You must provide your email address with your query");
            this.RuleFor(a => a.Name).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().Length(1, 255).WithMessage("You must provide your name with your query");
            this.RuleFor(a => a.Message).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().Length(1, 5000).WithMessage("You must include a message with your query");
        }
    }
}
