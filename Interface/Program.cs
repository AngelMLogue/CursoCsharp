namespace Interface
{
    class Program
    {
        public static void Main(string[] args)
        {
            Tiburon[] tiburones = new Tiburon[2]
            {
                new Tiburon("Tiburon Martillo",33),
                new Tiburon("Tiburon Ballena",21)
            };

            IPez[] pez = new IPez[]
            {
                new Sirena(29),
                new Tiburon("Tiburon Bala",73)
            };

            //Metodo MostrarPeces busca que tengan el metodo .Swim (IPez)
            MostrarPeces(pez);

            //Metodo MostrarAnimales busca que tengan Name (IAnimal)
            MostrarAnimales(tiburones);
        }

        //Este metodo, recibe una coleccion y la recorre
        public static void MostrarPeces(IPez[] pez)
        {
            Console.WriteLine("-- Mostramos los peces --\n");
            int i = 0;
            while (i < pez.Length)
            {
                /*Si la clase Tiburon, no implementara la interfaz IPez
                No podria utilizar el metodo Swim*/
                Console.WriteLine(pez[i].Swim());
                i++;
            }
        }

        public static void MostrarAnimales(IAnimal[] animals)
        {
            Console.WriteLine("-- Mostramos los peces --\n");
            int i = 0;
            while (i < animals.Length)
            {
                /*Si la clase Tiburon, no implementara la interfaz IAnimal
                No podria utilizar el metodo Swim*/
                Console.WriteLine(animals[i].nombre);
                i++;
            }
        }
    }

    public class Sirena : IPez
    {
        public int velocidad { get; set; }
        public Sirena(int velocidad)
        {
           this.velocidad = velocidad;
        }
        public string Swim()
        {
            return $"La velocidad de la sirena es {velocidad}";
        }
    }
    public class Tiburon : IAnimal, IPez
    {
        public string nombre {get; set;}
        public int velocidad {get; set;}

        //Para poder hacer un arreglo necesitamos un constructor
        public Tiburon(string Nombre,int velocidad)
        {
            this.nombre = Nombre;
            this.velocidad = velocidad;
        }

        public string Swim()
        {
            return $"la velocidad de {nombre} es {velocidad} KM/H";
        }
    }

    public interface IAnimal
    {
        public string nombre { get; set; }

    }

    public interface IPez
    {
        public int velocidad { get; set; }
        public string Swim();
    }
}