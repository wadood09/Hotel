using My_Dapper_DTO_Project_Testcase.DTO;

namespace My_Dapper_DTO_Project_Testcase.Models.Entities
{
    public class User : Auditables
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Dob { get; set; }
        public decimal Wallet { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public static string? LoggedInUserEmail { get; set; }

        public static implicit operator User(UserResponseModel v)
        {
            return new User()
            {
                FirstName = v.FirstName,
                LastName = v.LastName,
                Dob = v.
            }
        }
    }
}