using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<String, String> table = new HashTable<string, string>(2);
            table.Add("Name", "Ivan");
            table.Add("Surname", "Petrov");
            try
            {
                table.Add("Surname", "Petrov");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            table.Add("Phone Number", "1234567890");

            var val = table.GetValue("Surname");
            Console.WriteLine(val);
            try
            {
                val = table.GetValue("Bad");
            }catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            table.Clear();

            table.Add("Name", "Ivan");
            table.Add("Surname", "Petrov");
            table.Add("Phone Number", "1234567890");
            Console.ReadKey();
        }
    }
}
