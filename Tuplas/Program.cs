namespace Tuplas
{
    class Program
    {
        public static void Main(string[] args)
        {

            (int id, string nombre) productos = (1, "String");

            Console.WriteLine($"Id: {productos.id} Text: {productos.nombre}");

            //Ah diferencias de los elementos anonimos si podemos editar los valores
            //de los atributos de los objetos
            productos.nombre = "String2";

            Console.WriteLine($"Id: {productos.id} Text: {productos.nombre}");

            var persona = (23, "Miguel");
            Console.WriteLine($"Id: {persona.Item1} Text: {persona.Item2}");

            var personas = new[]
            {
                (1, "Pedro"),
                (2, "Jose")
            };

            foreach (var p in personas)
            {
                Console.WriteLine($"{p.Item1} {p.Item2}");
            }

            (int id, string nombre)[] personas2 = new[]
            {
                (3, "Mauricio"),
                (4, "Juan")
            };

            foreach (var p2 in personas2)
            {
                Console.WriteLine($"{p2.id} {p2.nombre}");
            }

            var cityInfo = GetLocation();
            Console.WriteLine($"Latitud: {cityInfo.latitud} Longitud: {cityInfo.longitud} Nombre: {cityInfo.nombre}");

            var (_,lgn,_) = GetLocation();
            Console.WriteLine($"\nLa longitud es:{lgn}");
        }

        public static (float latitud, float longitud, string nombre) GetLocation()
        {
            float latitud = 2.25f;
            float longitud = -1.25f;
            string nombre = "Monterrey";

            return (latitud,longitud,nombre);
        }
    }
}