using Food_Application_Project.Manager.Implementation;
using Food_Application_Project.Manager.Interface;


namespace Food_Application
{
    public class StartUp
    {
        IFoodManager foodManager = new FoodManager();
        IOrderingManager orderingManager = new OrderingManager();
        IDepositManager depositManager = new DepositManager();
        IWalletManager walletManager = new WalletManager();
        IUserManager userManager = new UserManager();
        public void Create()
        {
            if (!Directory.Exists("foodApp")) Directory.CreateDirectory("foodApp");

            var deposit = Path.Combine("foodApp", "deposits.txt");
            if (!File.Exists(deposit)) File.Create(deposit);
            else depositManager.UpdateList();

            var food = Path.Combine("foodApp", "foods.txt");
            if (!File.Exists(food)) File.Create(food);
            else foodManager.UpdateList();

            var Ordering = Path.Combine("foodApp", "orderings.txt");
            if (!File.Exists(Ordering)) File.Create(Ordering);
            else orderingManager.UpdateList();

            var user = Path.Combine("foodApp", "users.txt");
            if (!File.Exists(user)) File.Create(user);
            else
            {
                userManager.CheckAndAddSuperAdmin();
                userManager.UpdateList();
            }

            var wallet = Path.Combine("foodApp", "wallets.txt");
            if (!File.Exists(wallet)) File.Create(wallet);
            else walletManager.UpdateList();
        }
    }
}