namespace HeartwoodTrees.ViewModels.Contact
{
    using HeartwoodTrees.Business.Asserts;
    using HeartwoodTrees.Business.Notifications;

    public static class ContactViewModelExtensions
    {
        public static QueryDetails Model(this QueryViewModel queryDetails)
        {
            ArgumentAssert.IsNotNull(queryDetails, "queryDetails");
            return new QueryDetails
                       {
                           Email = new EmailAddress
                                       {
                                           Address = queryDetails.Email,
                                           Name = queryDetails.Name
                                       },
                           Name = queryDetails.Name,
                           Message = queryDetails.Query,
                           Phone = queryDetails.Phone
                       };
        }
    }
}