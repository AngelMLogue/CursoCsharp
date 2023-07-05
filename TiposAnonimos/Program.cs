namespace TiposAnonimos
{
    class Program
    {
        public static void Main(string[] args)
        {
            var lista = new
            {
                Nombre = "Manuel",
                Apellido = "Saucedo"
            };

            Console.WriteLine($"Nombre: {lista.Nombre}");

            var persona = new[]
            {
                new {Nombre = "Manuel", Apellido = "Vidal"},
                new {Nombre = "Miguel", Apellido = "Loera"}

            };

            foreach ( var item in persona) 
            {
                Console.WriteLine($"Nombre: {item.Nombre} Apellido: {item.Apellido}");
            }
        }
    }
}