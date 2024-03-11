namespace My_Dapper_Project_2.Models.Entities
{
    public class Admin : Auditables
    {
        public string UserEmail { get; set; } = default!;
        public static int LoggedInAdminId { get; set; }
    }
}