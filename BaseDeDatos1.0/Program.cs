using BaseDeDatos1._0;

namespace BasdeDeDatos1._0
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                BeerDBContext db = new BeerDBContext("TM-ANGELLOERA", "CsharpDB", "sa", "1800");
                bool again = true;
                int op = 0;
                do
                {
                    ShowMenu();
                    Console.WriteLine("\nElija una opción");
                    op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            Show(db);
                            break;
                        case 2:
                            Insert(db);
                            break;
                        case 5:
                            again = false;
                            break;
                    }
                }
                while (again);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo conectar");
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("\n----------MENU----------");
            Console.WriteLine("1.-Mostrar");
            Console.WriteLine("2.-Agregar");
            Console.WriteLine("3.-Editar");
            Console.WriteLine("4.-Eliminar");
            Console.WriteLine("5.-Salir");
        }
        public static void Show(BeerDBContext db)
        {
            Console.Clear();
            Console.Write("Cervezas de la Base de datos\n");
            Console.Write("ID / Nombre / MarcaID\n");
            List<Beer> beers = db.GetAll();

            foreach (var i in beers)
            {
                Console.WriteLine($"ID: {i.ID} Nombre: {i.Name}");
            }

        }

        public static void Insert(BeerDBContext db)
        {
            Console.Clear();
            Console.WriteLine("Agregar Nueva cerveza\n");
            Console.WriteLine("Escribe el nombre");
            string name = Console.ReadLine();
            Console.WriteLine("Escribe el id de la marca");
            int brandId = int.Parse(Console.ReadLine());

            Beer cerveza = new Beer(name, brandId);
            db.Add(cerveza);
        }
    }
}
