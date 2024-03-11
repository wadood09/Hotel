namespace My_Dapper_Project_2.Models.Entities
{
    public class Customer : Auditables
    {
        public string UserEmail { get; set; } = default!;
        public int WalletId { get; set; }
        public static int LoggedInCustomerId { get; set; }
    }
}