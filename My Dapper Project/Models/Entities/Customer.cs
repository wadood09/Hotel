namespace My_Dapper_Project.Models.Entities
{
    public class Customer : Auditables
    {
        public string UserEmail { get; set; } = default!;
        public static int LoggedInCustomerId { get; set; }
    }
}