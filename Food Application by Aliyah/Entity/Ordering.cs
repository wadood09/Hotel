public class Ordering : Base
{
    
    public string SellerAccountNumber{get;set;}
    public string BuyerAccountNumber{get;set;}
    public double Price{get;set;}
    public string RefNo{get;set;}
    public string FoodName{get;set;}
    public int Quantity{get;set;}

    public Ordering(string buyerAccountNumber, double price, string refNo, string foodName, int quantity)
    {
        SellerAccountNumber = "0";
        BuyerAccountNumber = buyerAccountNumber;
        Price = price;
        RefNo = refNo;
        FoodName = foodName;
        Quantity = quantity;
    }

    public Ordering()
    {
    }

    public override string ToString()
    {
        return $"{Id}\t{CreatedAt}\t{SellerAccountNumber}\t{BuyerAccountNumber}\t{Price}\t{RefNo}\t{FoodName}\t{Quantity}";
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
            Quantity = int.Parse(order[7])
        };
    }
}