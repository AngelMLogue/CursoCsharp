namespace ExcepcionPersonalizada
{
    class Program
    {
        public static void Main(string[] args) 
        {
            try
            {
                Beer cerveza = new Beer()
                {
                    nombre = "Carta",
                    //marca = "light"
                };

                Console.WriteLine(cerveza);
            }
            catch (InvalidBeer e)
            {
                Console.WriteLine(e.Message);

                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                throw;
            }

        }

        public class InvalidBeer : Exception
        {
            public InvalidBeer() : base("La cerveza no tiene nombre o marca")
            {
                
            }
        }

        public class Beer
        {
            public string nombre { get; set; }
            public string marca { get; set; }

            public override string ToString()
            {
                if (nombre == null || marca == null)
                    throw new InvalidBeer();

                return $"Nombre: {nombre} Marca: {marca}";
            }
        }
    }
}
