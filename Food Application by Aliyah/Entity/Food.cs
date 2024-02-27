namespace Food_Application_Project.Entity
{
    public class Food : Base
    {
        public string FoodName { get; set; }
        public double Price { get; set; }
        public string FoodType { get; set; }
        public Food(string foodName, string foodType, double price)
        {
            FoodName = foodName;
            Price = price;
            FoodType = foodType;
        }

        public Food()
        { }

        public override string ToString()
        {
            return $"{Id}\t{CreatedAt}\t{FoodName}\t{Price}\t{FoodType}";
        }
        public static Food ToFood(string str)
        {
            var food = str.Split('\t');
            return new Food()
            {
                Id = int.Parse(food[0]),
                CreatedAt = DateTime.Parse(food[1]),
                FoodName = food[2],
                Price = double.Parse(food[3]),
                FoodType = food[4],
            };
        }
    }
}
