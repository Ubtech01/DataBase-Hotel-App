namespace Hotel.Models
{
    public class RegisteredUser
    {

        public RegisteredUser()
        {
                Id = Guid.NewGuid();
                RegisteredDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public DateTime RegisteredDate { get; set; }
        public RegisteredUser(Guid Id, string firstName, string lastName, string email, string password, DateTime date)
        {
            
        }
    }
}
