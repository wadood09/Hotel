namespace My_Dapper_Project_2.Models.Entities
{
    public class Staff : Auditables
    {
        public int OrganizationId { get; set; }
        public string AccessLevel { get; set; } = default!;
    }
}