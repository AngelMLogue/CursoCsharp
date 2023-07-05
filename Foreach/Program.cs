namespace Foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            var numero = 2;

            //List<int> numeros = new()
            //{
            //    1,2,3,4
            //};

            var numeros = new List<int>()
            {
                1,2,3,4
            };

            foreach (var i in numeros)
            {
                Console.WriteLine(i);
            }

            var persona = new List<persona>()
            {
                new persona(){nombre = "Manuel", nacionalidad="Mexicano"},
                new persona(){nombre = "Manuel", nacionalidad="Estado Unidense"}

            };

            show(persona);
            persona.RemoveAt(0);
            show(persona);

        }

        static void show(List<persona> estudiantes)
        {
            Console.WriteLine("-- Listado de estudiantes --");
            foreach (var persona in estudiantes)
            {
                Console.WriteLine($"Nombre: {persona.nombre} Nacionalidad: {persona.nacionalidad}");
            }
        }

        public class persona
        {
            public string nombre { get; set; }
            public string nacionalidad { get; set; }
        }
    }
}