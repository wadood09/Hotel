class HotelManager : IHotelManager
{
    static List<Hotel> Hotels = new List<Hotel>();
    public Hotel AddHotel(Hotel hotel)
    {
        if (IsExist(hotel.Name))
        {
            Console.WriteLine($"Hotel with name {hotel.Name} already exists");
        }
        else
        {
            Hotels.Add(hotel);
            Console.WriteLine("Hotel Registration Successfull");
        }
        return hotel;
    }

    public bool IsExist(string name)
    {
        foreach (var hotel in Hotels)
        {
            if (hotel.Name == name)
            {
                return true;
            }
        }
        return false;
    }

    public List<Hotel> Get(int id)
    {
        List<Hotel> hotels = new();
        foreach (var hotel in Hotels)
        {
            if(hotel.AdminId == id)
            {
                hotels.Add(hotel);
            }
        }
        return hotels;
    }
    public Hotel GetHotel(int id)
    {
        foreach (var hotel in Hotels)
        {
            if(hotel.ID == id)
            {
                return hotel;
            }
        }
        return null;
    }

    public bool HotelNameExists(string name)
    {
        foreach (var hotel in Hotels)
        {
            if(hotel.Name.ToLower() == name.ToLower())
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveHotel(Hotel hotel)
    {
        Hotels.Remove(hotel);
    }

    public List<Hotel> GetAll()
    {
        return Hotels;
    }
}