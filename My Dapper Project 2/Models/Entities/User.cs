namespace My_Dapper_Project_2.Models.Entities
{
    public class User
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime Dob { get; set; }
        public decimal Wallet { get; set; }
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Role { get; set; } = default!;
        public static string LoggedInUserEmail { get; set; } = default!;
    }
}
