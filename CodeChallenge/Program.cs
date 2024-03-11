using System.Text;

static bool IsPalindrome(string s)
{
    const string alphaNumerics = "abcdefghijklmnopqrstuvwxyz1234567890";
    StringBuilder word = new();
    foreach (var item in s.ToLower())
    {
        if (alphaNumerics.Contains(item))
        {
            word.Append(item);
        }
    }
    if (string.IsNullOrWhiteSpace(word.ToString()))
        return true;
    StringBuilder palindrome = new();
    for (int i = word.Length - 1; i >= 0; i--)
    {
        palindrome.Append(word[i]);
    }
    if (word.Equals(palindrome))
        return true;
    else
        return false;
}


static bool IsValidMountainArray(params int[] arr)
{
    if (arr.Length < 3)
        return false;
    int max = arr.Max();
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] == max)
            break;
        if (i == arr.Length - 1)
            break;
        if (arr[i] > arr[i + 1] || arr[i] == arr[i + 1])
            return false;
    }
    for (int i = arr.Length - 1; i >= 0; i--)
    {
        if (arr[i] == max)
            break;
        if (i == 0)
            break;
        if (arr[i] > arr[i - 1] || arr[i] == arr[i - 1])
            return false;
    }
    return true;
}