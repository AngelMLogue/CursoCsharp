namespace MetodosComunes
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<int> numeros = new List<int>()
            {
                1,3,4,5,7,3
            };

            //Insertar
            numeros.Insert(1, 32);

            Show(numeros);

            //Existe o no
            if (numeros.Contains(32))
            {
                Console.WriteLine("Existe");
            }
            else
            {
                Console.WriteLine("No existe");
            }

            //Posicion
            int pos = numeros.IndexOf(321);
            if ( pos >= 0 )
            {
                Console.WriteLine("Existe en la lista");
            }
            else
            {
                Console.WriteLine("No existe en la lista");
            }

            //Ordenar
            numeros.Sort();
            Show(numeros);

            //Agregar lista
            var pares = new List<int>()
            {
                20,40,60,80,100
            };

            numeros.AddRange(pares);

            Show(numeros);

        }

        public static void Show(List<int> numeros)
        {
            Console.WriteLine("Lista numeros");
            foreach (int i in numeros)
            {
                Console.WriteLine(i);
            }
        }
    }
}