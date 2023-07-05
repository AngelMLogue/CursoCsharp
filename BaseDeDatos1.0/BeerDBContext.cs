using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos1._0
{
    internal class BeerDBContext : DB
    {
        public BeerDBContext(string server, string db, string us, string pass) : base(server, db, us, pass)
        {
        }

        
        public List<Beer> GetAll()
        {
            Open();
            var beers = new List<Beer>();
            string query = "SELECT ID, Name, BrandID FROM Beer";
            SqlCommand command = new SqlCommand(query, _connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string Name = reader.GetString(1);
                int BrandID = reader.GetInt32(2);

                beers.Add(new Beer(ID, Name, BrandID));
            }

            Close();

            return beers;
        }

        public void Add(Beer beer)
        {
            Open();
            string Query = "INSERT INTO Beer (Name,BrandID) " +
                "VALUES (@name,@brandid)";
            SqlCommand command = new SqlCommand(Query, _connection);
            command.Parameters.AddWithValue("@name", beer.Name);
            command.Parameters.AddWithValue("@brandid", beer.BrandID);
            command.ExecuteNonQuery();
            Close();
        }
    }
}
