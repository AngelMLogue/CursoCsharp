using BD;
using EntityFrameworkSystem;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EntityFrameworkSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //OB = Option Builder
            DbContextOptionsBuilder<CsharpDbContext> optionsBuilder = new DbContextOptionsBuilder<CsharpDbContext>();
            optionsBuilder.UseSqlServer("Server = TM-ANGELLOERA; Database = CsharpDB; User = sa; Password =1800; TrustServerCertificate=True");

            bool again = true;
            int op = 0;

            do
            {
                ShowMenu();
                Console.WriteLine("Elige una opción:");
                op = int.Parse(Console.ReadLine());

                switch (op) 
                {
                    case 1:
                        Show(optionsBuilder);
                        break;
                    case 2:
                        Add(optionsBuilder); 
                        break;
                    case 3:
                        Edit(optionsBuilder);
                        break;
                    case 4:
                        Delete(optionsBuilder);
                    break;
                    case 5:
                        again = false;
                        break;
                }
            }
            while (again);
        }

        private static void Delete(DbContextOptionsBuilder<CsharpDbContext> optionsBuilder)
        {
            Console.Clear();
            Show(optionsBuilder);
            Console.WriteLine("Eliminar cerveza");
            Console.WriteLine("Escribe el id de tu cerveza");
            int id = int.Parse(Console.ReadLine());
            using (var context = new CsharpDbContext(optionsBuilder.Options))
            {
                Beer beer = context.Beers.Find(id);

                if (beer != null)
                {
                    context.Beers.Remove(beer);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Cerveza no encontrado");
                }

            }
        }

        private static void Edit(DbContextOptionsBuilder<CsharpDbContext> optionsBuilder)
        {
            Console.Clear();
            Show(optionsBuilder);
            Console.WriteLine("Editar cerveza");
            Console.WriteLine("Escribe el id de tu cerveza");
            int id = int.Parse(Console.ReadLine());
            using (var context = new CsharpDbContext(optionsBuilder.Options))
            {
                Beer beer = context.Beers.Find(id);

                    if(beer != null)
                    {
                        Console.WriteLine("Escribe el nombre:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Escribe el id de la marca");
                        int branId = int.Parse(Console.ReadLine());
                        beer.Name = name;
                        beer.BrandId = branId;
                        context.Entry(beer).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Cerveza no encontrado");
                    }

            }

        }


        private static void Add(DbContextOptionsBuilder<CsharpDbContext> optionsBuilder)
        {
            Console.Clear();
            Console.WriteLine("Agregar nueva cerveza");
            Console.WriteLine("Escribe el nombre:");
            string name = Console.ReadLine();
            Console.WriteLine("Escribe el id de la marca:");
            int brandId = int.Parse(Console.ReadLine());

            using (var context = new CsharpDbContext(optionsBuilder.Options))
            {
                Beer beer = new Beer()
                {
                    Name = name,
                    BrandId = brandId
                };
                context.Add(beer);
                context.SaveChanges();
            }
        }

        private static void Show(DbContextOptionsBuilder<CsharpDbContext> optionsBuilder)
        {
            Console.Clear();
            Console.WriteLine("Cervezas en la base de datos");
            using(var context = new  CsharpDbContext(optionsBuilder.Options))
            {
                List<Beer> beers = context.Beers.OrderBy(b => b.Name).ToList();
                /*List<Beer> beers2 = (from b in context.Beers
                                     //where b.BrandId == 2
                                     orderby b.Name
                                     select b).Include(b => b.Brand).ToList();*/

                foreach (var beer in beers) 
                {
                    Console.WriteLine($"{beer.Id} - {beer.Name} "/*{beer.Brand.Name}*/);
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\n----------MENU----------");
            Console.WriteLine("1.-Mostrar");
            Console.WriteLine("2.-Agregar");
            Console.WriteLine("3.-Editar");
            Console.WriteLine("4.-Eliminar");
            Console.WriteLine("5.-Salir");
        }
    }
}
