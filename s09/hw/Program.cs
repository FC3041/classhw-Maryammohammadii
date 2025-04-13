namespace hw;
using System;
using System.Collections.Generic;
using System;

class Program
{
    static void Main(string[] args)
    {
        
        string[] people = new string[100]; 
        int count = 0; 

        while (true)
        {
            
            Console.WriteLine("1. Add Person");
            Console.WriteLine("2. List People");
            Console.WriteLine("3. Exit");
            Console.Write("  :");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                
                if (count < people.Length)
                {
                    
                    string name = Console.ReadLine();
                    people[count] = name;
                    count++;
                
                }
                
            }
            else if (choice == "2")
            {
                
                if (count == 0)
                {
                    Console.WriteLine("null");
                }
                else
                {
                    
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {people[i]}");
                    }
                }
            }
            else if (choice == "3")
            {
                
                break;
            }
            else
            {
                Console.WriteLine("...");
            }
        }
    }
}