namespace My_Dapper_DTO_Project_Testcase.Models.Entities
{
    public class Admin : Auditables
    {
        public string UserEmail { get; set; } = default!;
        public static string LoggedInAdminId { get; set; } = default!;
    }
}