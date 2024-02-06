public static class StringExtension
{
    const string specialCharacters = "~!@#$%^&*()_+=`{}[]\\|':\";.,/?<>";
    public static bool ContainsUpperCase(this string str)
    {
        if (string.IsNullOrEmpty(str) == true)
        {
            return false;
        }
        else
        {
            foreach (char word in str)
            {
                if(specialCharacters.Contains(word))
                continue;
                if (word == char.ToUpper(word))
                {
                    return true;
                }
            }
            return false;
        }
    }


    public static int HowManyIsUpperCase(this string str)
    {
        if (string.IsNullOrEmpty(str) == false)
        {
            string[] words = str.Split(',', '!', '`', '~', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '=', '{', '}', '[', ']', '|', '\\', ':', ';', '\'', '\"', '<', '>', '?', '/', ' ');
            int count = 0;
            foreach (string word in words)
            {
                foreach (char letter in word)
                {
                    if (specialCharacters.Contains(letter))
                        continue;
                    if (letter == char.ToUpper(letter))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        else return 0;
    }


    public static bool ContainsLowerCase(this string str)
    {
        if (string.IsNullOrEmpty(str) == false)
        {
            foreach (char word in str)
            {
                if(specialCharacters.Contains(word))
                continue;
                if (word == char.ToLower(word))
                {
                    return true;
                }
            }
            return false;
        }
        else return false;
    }


    public static int HowManyIsLowerCase(this string str)
    {
        if (string.IsNullOrEmpty(str) == false)
        {
            string[] words = str.Split(',', '!', '`', '~', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '=', '{', '}', '[', ']', '|', '\\', ':', ';', '\'', '\"', '<', '>', '?', '/', ' ');
            int count = 0;
            foreach (string word in words)
            {
                foreach (char letter in word)
                {
                    if (specialCharacters.Contains(letter))
                        continue;
                    if (letter == char.ToLower(letter))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        else return 0;
    }


    public static bool ContainsSpecialCharacter(this string str)
    {
        if (string.IsNullOrEmpty(str) == false)
        {
            foreach (char word in str)
            {
                if (specialCharacters.Contains(word))
                {
                    return true;
                }
            }
            return false;
        }
        else return false;
    }

    
    public static int HowManyIsSpecialCharacter(this string str)
    {
        if (string.IsNullOrEmpty(str) == false)
        {
            int count = 0;
            foreach (char letter in str)
            {
                if (specialCharacters.Contains(letter))
                {
                    count++;
                }

            }
            return count;
        }
        else return 0;
    }
}