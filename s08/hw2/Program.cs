
namespace hw2;
class Program
{
    static void Main()
    {
        Console.WriteLine("i study math:");
        string? input = Console.ReadLine();

        if (input != null)
        {
            string revS = RevW(input);
            Console.WriteLine(":");
            Console.WriteLine(revS);
        }
        else
        {
            Console.WriteLine("!");
        }
    }

    static string RevW(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return " !";
        }

        
        string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        
        Array.Reverse(words);

        
        return string.Join(" ", words);
    }
}