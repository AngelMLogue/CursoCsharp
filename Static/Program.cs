using System.Diagnostics.CodeAnalysis;

namespace Static
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Instanciación de la clase sin static
            Persona Juan = new Persona();
            Juan.Age = 29;
            Persona Manuel = new Persona();
            Manuel.Age = 32;

            Console.WriteLine($"la edad es: {Juan.Age} de edad");
            Console.WriteLine($"la edad es: {Manuel.Age} de edad");
            Console.WriteLine(Persona.Contador());

            a.Mensaje();
        }

        //Clase estatica
        public static class a
        {
            public static void Mensaje()
            {
                Console.WriteLine("Mensaje Enviado");
            }
        }

        //Si la clase es Static sus objetos deben ser Static
        public class Persona {

            //Static en Propiedad
            public static int Count = 0;
            [AllowNull]
            public  string Name  { get; set; }
            public  int Age { get; set; }

            public Persona()
            {
                Count++;
            }

            //Static a nivel metodo
            public static string Contador()
            {
                //Este es un ejemplo de string interpolation
                return $"El contador lleva {Count} numero de veces activo";
            }
        }

    }
}

