namespace  DapperClass
{
    public class Student
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Email {get;set;}
        public override string ToString()
        {
            return $"{Name} {Email}";
        }
    }
}