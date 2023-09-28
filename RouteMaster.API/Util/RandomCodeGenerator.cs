namespace RouteMaster.API;

public class RandomCodeGenerator
{
    private static readonly Random random = new();
    private const string chars = "0123456789";

    public static string GenerateRandomCode(int length)
    {
        char[] code = new char[length];
        for (int i = 0; i < length; i++)
        {
            code[i] = chars[random.Next(chars.Length)];
        }
        return new string(code);
    }
}