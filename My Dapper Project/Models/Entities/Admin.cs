namespace My_Dapper_Project.Models.Entities
{
    public class Admin : Auditables
    {
        public string UserEmail { get; set; } = default!;
        public static int LoggedInAdminId { get; set; }
    }
}