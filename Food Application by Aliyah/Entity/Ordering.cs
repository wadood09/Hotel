public class Ordering : Base
{
    
    public string SellerAccountNumber{get;set;}
    public string BuyerAccountNumber{get;set;}
    public double Price{get;set;}
    public string RefNo{get;set;}
    public string FoodName{get;set;}

    public override string ToString()
    {
        return $"{Id}\t{CreatedAt}\t{SellerAccountNumber}\t{BuyerAccountNumber}\t{Price}\t{RefNo}\t{FoodName}";
    }
    public static Ordering ToOrder(string str)
    {
        var order = str.Split('\t');
        return new Ordering()
        {
            Id = int.Parse(order[0]),
            CreatedAt = DateTime.Parse(order[1]),
            SellerAccountNumber = order[2],
            BuyerAccountNumber = order[3],
            Price = double.Parse(order[4]),
            RefNo = order[5],
            FoodName = order[6],
        };
    }
}