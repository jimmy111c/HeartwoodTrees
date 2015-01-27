namespace HeartwoodTrees.Business.Notifications
{
    public class QueryDetails : IQueryDetails
    {
        public EmailAddress Email { get; set; }

        public string Message { get; set; }

        public string Phone { get; set; }

        public string Name { get; set; }
    }
}
