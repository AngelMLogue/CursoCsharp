namespace LINQ
{
    class Program
    {
        public static void Main(string[] args)
        {
            var Cervezas = new List<Beer>()
            {
                new Beer()
                {
                    Nombre = "Tecate",
                    Pais = "Mexico"
                },
                new Beer()
                {
                    Nombre = "Ebisn",
                    Pais = "Alemania"
                },
                new Beer()
                {
                    Nombre = "Tequito",
                    Pais = "Brazil"
                },
                new Beer()
                {
                    Nombre = "Sequito",
                    Pais = "Brazil"
                }
            };
            
            foreach (var i in Cervezas)
                Console.WriteLine(i);

            Console.WriteLine("------------\n");

            //Select
            var nombres = from x in Cervezas
                          select new
                          {
                              nombre = x.Nombre,
                              Letters = x.Nombre.Length,
                              Fixed = 1
                          };

            Console.WriteLine("--------------");
            foreach (var i in nombres ) 
            {
                Console.WriteLine($"Nombre: {i.nombre} Numero de letras: {i.Letters} Fijo: {i.Fixed}");
            }

            var nombresreal = from x in nombres
                              select new
                              {
                                  nombre = x.nombre
                              };

            Console.WriteLine("--------------");
            foreach ( var i in nombresreal) {
                Console.WriteLine($"Nombre: {i.nombre}");
            };

            var filtro = from x in Cervezas
                         where x.Pais == "Brazil"
                         || x.Pais == "Alemania"
                         select x;

            Console.WriteLine("--------------");
            foreach (var i in filtro)
            {
                Console.WriteLine(i);
            }

            var filtropais = from x in Cervezas
                             orderby x.Pais descending
                             select x;

            Console.WriteLine("--------------");
            foreach (var i in filtropais)
            {
                Console.WriteLine(i);
            }

        }
    }

    public class Beer
    {
        public string Nombre { get; set; }
        public string Pais { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Nombre} Pais: {Pais}";
        }
    }
}