
using System.Security.Cryptography;



Human hm = new Human();

hm.name = "Tobi";
hm.age = 12;
hm.height = 1.76;

//convert the hm profile to string
var newObject = hm.ToString();


//writing to file
string filePath = @"C:\Users\AIRIS TECHNOVATION\OneDrive\CodeLearnersHub\Csharp-Journey\classes in sprint\Sprint 2 classes\Overiding toString\Object.txt";

if(!File.Exists(filePath))
{
    using(StreamWriter obj = new StreamWriter(filePath))
    {
        Console.WriteLine($"File created in {filePath}");
        obj.WriteLine(newObject);
    }
}

//reading from file and converting to object
if(File.Exists(filePath))
{
    StreamReader newHuman = new StreamReader(filePath);

    var human = newHuman.ReadLine();

  //Split the result from file 
    string[] arr = Human.ConvertFileReadToStringArray(human);

    var newestHuman = Human.ConvertToObject(arr);

    if(newestHuman.ToString() == newObject)
    {
        Console.WriteLine("You are on point");
    }

}