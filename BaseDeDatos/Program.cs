using System.Data.SqlClient;

namespace BaseDeDatos
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                BeerDbContext db = new BeerDbContext("TM-ANGELLOERA", "CsharpDB", "sa", "1800");
                bool again = true;
                int op = 0;

                do
                {
                    ShowMenu();
                    Console.WriteLine("Elija una opción: ");
                    op = int.Parse(Console.ReadLine());

                    switch (op) 
                    {
                        case 1:
                            Show(db);
                            break;
                        case 2:
                            Insert(db);
                            break;
                        case 3:
                            Edit(db);
                            break;
                        case 4:
                            Delete(db);
                            break;
                        case 5:
                            again = false;
                            break;
                    }
                }
                while (again); 

            }
            catch (SqlException ex)
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
        
        public static void Show(BeerDbContext db)
        {
            Console.Clear();
            Console.Write("Cervezas de la Base de datos\n");
            Console.Write("ID / Nombre / MarcaID\n");
            List<Beer> Cervezas = db.GetAll();

            foreach (var i in Cervezas)
            {
                Console.WriteLine($"ID: {i.ID} Nombre: {i.Name}");
            }

        }

        public static void Insert(BeerDbContext db)
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

        public static void Edit(BeerDbContext db)
        {
            Console.Clear();
            Show(db);
            Console.WriteLine("Editar cerveza");
            Console.WriteLine("Escribe el id de la cerveza a editar:");
            int id = int.Parse(Console.ReadLine());

            Beer beer = db.Get(id);

            if(beer != null)
            {
                Console.WriteLine("Escribe el nombre");
                string name = Console.ReadLine();
                Console.WriteLine("Escribe el id de la marca");
                int brandId = int.Parse(Console.ReadLine());

                beer.Name = name;
                beer.BrandID = brandId;

                db.Edit(beer);
            }
            else
            {
                Console.WriteLine("La id no coincide con ninguna");
            }
        }

        public static void Delete(BeerDbContext db)
        {
            Console.Clear();
            Show(db);
            Console.WriteLine("Editar cerveza");
            Console.WriteLine("Escribe el id de la cerveza a eliminar:");
            int id = int.Parse(Console.ReadLine());

            Beer beer = db.Get(id);

            if (beer != null)
            {

                db.Delete(id);
            }
            else
            {
                Console.WriteLine("La id no coincide con ninguna");
            }
        }
    }
}