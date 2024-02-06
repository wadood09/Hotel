static class ExtensionMethods
{
    public static string ToPascalCase(this string str)
    {
        string[] words = str.Split(' ');
        foreach (string word in words)
        {
            if(word is null)
            {
                continue;
            }
            
        }
        for (int i = 0; i < words.Length; i++)
        {
            string holder = words[0];
            words[0] = char.ToUpper(words[0][0]).ToString();
            for (int j = 1; j < holder.Length; j++)
            {
                words[0] += holder[j];
            }
        }
        str = string.Join(" ",words);
        return str;
    }
}