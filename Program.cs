using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace KR
{
    class Program
    {/// <summary>
    /// Метод - вхідна точка програми. Представляє основні функції програми.
    /// </summary>
    /// <param name="args">Передача інформації</param>
        static void Main(string[] args)
        {
            const string q = "____________________________________________";
            
            try
            {
                Shop store = new Shop();
                Console.WriteLine(store);
                Console.WriteLine(q);
                Console.WriteLine("\n     L I S T   O F   P R O D U C T S\n");
                store.InputProducts("list1.txt");
                Console.WriteLine(q);
                store.Sort();
                Console.WriteLine(q);
                store.SearchByName();
                Console.WriteLine(q);
                store.Operations();
                Console.WriteLine(q);
                Console.WriteLine("Cart:");
                store.ShowCart();
                Console.WriteLine(q);
                store.BdaySale();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format of input");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow");
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Out of memory to create new object");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index is out of range");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File doesn't exist");
            }
            Console.ReadKey();
        }
    }
}
