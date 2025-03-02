namespace rocketship2
{
    public class Program
    {

        public static void Printhead()
        {
            Console.WriteLine(@"     ^      ");
            Console.WriteLine(@"    /|\     ");
            Console.WriteLine(@"   //|\\    ");
            Console.WriteLine(@"  ///|\\\   ");
        }

        
        public static void PrintTrunk()
        {
            Console.WriteLine(@" +-------+  ");
            Console.WriteLine(@" +*******+  ");
            Console.WriteLine(@" +*******+  ");
            Console.WriteLine(@" +*******+  ");
            Console.WriteLine(@" +*******+  ");
        }

       
        public static void Main(string[] args)
        {
            
            Printhead();
            
            PrintTrunk();
            
            Console.WriteLine(@" +-------+  ");
            
            PrintTrunk();
            
            Printhead();
        }
    }
}
