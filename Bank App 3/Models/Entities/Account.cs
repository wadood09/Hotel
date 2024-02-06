public class Account : BaseEntity
{
    public string Number;
    public string AccountTypeName;
    public double Balance;
    public string CustomerBvn;

    public Account(int sn, string number, string accountTypeName, double balance, string customerBvn) : base(sn)
    {

    }
}