namespace My_File_Project.Models.Extensions
{
    public static class StringExtensions
    {
        public static string ToPascalCase(this string str)
        {
            string[] words = str.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                string holder = words[0];
                words[0] = char.ToUpper(words[0][0]).ToString();
                for (int j = 1; j < holder.Length; j++)
                {
                    words[0] += holder[j];
                }
            }
            str = string.Join(" ", words);
            return str;
        }
    }
}