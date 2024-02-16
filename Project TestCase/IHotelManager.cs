interface IHotelManager
{
    public bool IsExist(string name);
    public Hotel AddHotel(Hotel hotel);
    public List<Hotel> Get(int id);
    public List<Hotel> GetAll();
    public bool HotelNameExists(string name);
    public void RemoveHotel(Hotel hotel);
    public Hotel GetHotel(int id);
}