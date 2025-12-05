namespace Domain
{
    public class User
    {
        public long Id { get; set; }

        public required string UserName { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }
    }
}
