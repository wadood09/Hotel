public class AccountType : BaseEntity
{
    public string Name;
    public double OpeningBalance;
    public double MinimumBalance;
    public double TranferLimit;

    public AccountType(int sn, string name, double openingBalance, double minimumBalance, double transferLimit) : base(sn)
    {
        Name = name;
        OpeningBalance = openingBalance;
        MinimumBalance = minimumBalance;
        TranferLimit = transferLimit;
    }
}