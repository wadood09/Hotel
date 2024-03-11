namespace My_Dapper_Project_2.Models.Entities
{
    public class Organization : Auditables
    {
        public string Name { get; set; } = default!;
        public int WalletId { get; set; }
    }
}