class AdminManager : IManager<Admin>
{
    static List<Admin> Admins = new List<Admin>();
    public Admin Add(Admin admin)
    {
        if(IsExist(admin.Email))
        {
            Console.WriteLine($"Admin with email {admin.Email} already exists");
        }
        else
        {
            Admins.Add(admin);
            Console.WriteLine("Registration Successfull");
        }
        return admin;
    }

    public void DeleteDetails(Admin value)
    {
        Admins.Remove(value);
    }

    public Admin Get(int id)
    {
        foreach (var admin in Admins)
        {
            if(admin.ID == id)
            {
                return admin;
            }
        }
        return null;
    }

    public List<Admin> GetList(int id)
    {
        throw new NotImplementedException();
    }

    public bool IsExist(string email)
    {
        foreach (var admin in Admins)
        {
            if(admin.Email == email)
            {
                return true;
            }
        }
        return false;
    }

    public bool Login(string email, string password)
    {
        foreach (var admin in Admins)
        {
            if(admin.Email == email && admin.Password == password)
            {
                Admin.LoggedInAdminId = admin.ID;
                return true;
            }
        }
        return false;
    }
}