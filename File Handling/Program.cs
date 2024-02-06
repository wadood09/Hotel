// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;

Console.WriteLine("Hello, World!");

// DirectoryInfo info = new DirectoryInfo("Folder");
// info.Create();

// DirectoryInfo info2 = new DirectoryInfo("Folder\\New");
// info2.Create();

// string filePath = "Folder\\New\\newfile.txt";
// StreamWriter writer = new StreamWriter(filePath);
// writer.WriteLine("I am a bad boy");
// writer.Flush();
// writer.Close();
// FileInfo info1 = new FileInfo("Greetings.txt");
// info1.Create();
// FileStream file = File.Create("Folder\\New\\Test.txt");
// // File.Delete(filePath);



// StreamReader reader = new StreamReader(filePath);
// string content = reader.ReadLine();
// Console.WriteLine(content);
// string content2 = reader.ReadLine();
// Console.WriteLine(content2);
// reader.Close();


// string path1 = "C:\\Users\\WADOOD\\Videos\\Banshee";
// string path2 =  "C:\\Users\\WADOOD\\Videos\\GoT";
// DirectoryInfo info = new(path);
// string filePath = Path.ChangeExtension("Folder\\Greetings.txt", "mkv");//.GetFullPath("Folder\\Greetings"); // Directory.GetLogicalDrives();//.GetFiles("C:\\Users\\WADOOD\\Videos\\Bleach");//.GetDirectoryRoot(path1);//.GetDirectories("C:\\Users\\WADOOD");//.GetLastWriteTime(path2);//.GetLastAccessTime("C:\\Users\\WADOOD\\Videos\\Bleach");//.GetCurrentDirectory();//.EnumerateFileSystemEntries("C:\\Users\\WADOOD\\Videos\\GoT");//.EnumerateDirectories("C:\\Users\\WADOOD\\Videos");//.EnumerateFiles(path1);//.GetCreationTime("C:\\Users");//.Move(path1, path2);//.GetFiles(path);//.GetParent(path);//Path.GetDirectoryName(path);
// Console.WriteLine(filePath);
// // foreach (var item in filePath)
// {
//     Console.WriteLine(item);
// }
// info.Create();
// string file = "C:\\Users\\WADOOD\\OneDrive\\Desktop\\File Handling\\New\\file.csproj";
// FileInfo fileInfo = new(file);





// string directory = "C:\\Users\\WADOOD\\OneDrive\\Desktop\\File Handling\\Folder\\Greetings.txt";
// string directoryPath = Path.GetDirectoryName(directory);
// if(!Directory.Exists(directoryPath))
// {
//     Console.WriteLine("Creating directory...");
//     Directory.CreateDirectory(directoryPath);
//     Console.WriteLine("Directory created");
// }
// if(File.Exists(directory))
// {
//     Console.WriteLine("File Exists");
//     using(StreamReader reader = new(directory))
//     {
//         string str = reader.ReadToEnd();
//         Console.WriteLine(str);
//     }
// }







// string fileName = "New File.txt";
// FileStream file = File.Create(fileName);
// StreamWriter writer = new StreamWriter("File 2.txt");
// writer.WriteLine("I am a boy");
// writer.WriteLine("I am a boy");
// writer.Flush();
// writer.Close();

// StreamReader reader = new StreamReader("File 2.txt");
// string print = reader.ReadToEnd();
// Console.WriteLine(print);
// reader.Close();

// DirectoryInfo directory = new DirectoryInfo("Folder");
// directory.Create();

// string filePath = "Folder\\Greetings.txt";
// File.Create(filePath);
string newFolder = "Folder\\New Folder\\ Folder.txt";
// File.Create(newFolder);
StreamWriter writer = new StreamWriter(newFolder);
writer.WriteLine("I am a boy");
writer.Flush();
writer.Close();