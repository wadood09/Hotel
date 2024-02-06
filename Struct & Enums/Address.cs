public struct Address
{
    private string city;
    private string state;
    private string country;
    public string City
    {
        set{city = value;}
        get{return city;}
    }
    public string State
    {
        set{state = value;}
        get{return state;}
    }
    public string Country
    {
        set{country = value;}
        get{return country;}
    }
}