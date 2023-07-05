namespace Union
{
    class Program
    {
        public static void Main(string[] args)
        {
            var Cervezas = new List<Beer>() {
                new Beer
                {
                    Nombre = "Cerveza1",
                    Pais = "Pais1"
                },
                new Beer
                {
                    Nombre = "Cerveza2",
                    Pais = "Pais2"
                },
                new Beer
                {
                    Nombre = "Cerveza3",
                    Pais = "Pais3"
                }
            };

            var Paises = new List<Pais>()
            {
                new Pais
                {
                    Nombre = "Pais1",
                    Continente = "Continente1"
                },
                new Pais
                {
                    Nombre = "Pais2",
                    Continente = "Continente2"
                },
                new Pais
                {
                    Nombre = "Pais3",
                    Continente = "Continente3"
                }
            };

            var PaisesCervezas = from x in Cervezas
                                 join y in Paises on
                                 x.Pais equals y.Nombre
                                 select new
                                 {
                                     Nombre = x.Nombre,
                                     Pais = x.Pais,
                                     Continente = y.Continente
                                 };

            foreach (var x in PaisesCervezas)
            {
                Console.WriteLine($"Cerveza: {x.Nombre} Pais: {x.Pais} Contienente: {x.Continente}");
            }
        }
    }

    public class Beer
    {
        public string Nombre { get; set; }
        public string Pais { get; set; }

    }

    public class Pais
    {
        public string Nombre { get; set; }
        public string Continente { get; set; }
    }
}