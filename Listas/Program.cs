using System.Collections.Generic;
 
namespace Listas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numeros = new List<int>();
            numeros.Add(5);
            numeros.Add(2);

            Console.WriteLine(numeros.Count);

            List<int> numeros2 = new List<int>()
            {
                1,3,2,4,5,6,2,1,7,5,2
            };

            Console.WriteLine(numeros2.Count);

            numeros2.Add(43);

            Console.WriteLine(numeros2.Count);

            numeros.Clear();

            Console.WriteLine(numeros.Count);
        }
    }
}
