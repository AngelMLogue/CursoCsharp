namespace Excepcion
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string content = File.ReadAllText(@"C:\Users\Digitalizacion TM\Desktop\Hola.txt");
                Console.WriteLine(content);

                string content2 = File.ReadAllText(@"C:\Users\Digitalizacion TM\Desktop\Holaew.txt");
                Console.WriteLine(content2);

                throw new Exception("Ocurrio Algo inpensable");
            }
            catch(FileNotFoundException e) { 
                Console.WriteLine("Archivo no encontrado");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Aqui me eh ejecutado sin excepcion");
            }

        }
    }
}