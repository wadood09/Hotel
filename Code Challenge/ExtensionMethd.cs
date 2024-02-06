public static class ExtensionMethd
{
    public static int GetLength(this int num)
    {
        string convert = num.ToString();
        int result = convert.Length;
        return result;
    }
}