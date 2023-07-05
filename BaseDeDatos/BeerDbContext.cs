using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos
{
    public class BeerDbContext : DB
    {
        public BeerDbContext(string server, string db, string us, string pass) : base(server, db, us, pass)
        {
        }


        #region VerDatos
        public List<Beer> GetAll()
        {
            Connect();
            var Cervezas = new List<Beer>();
            string Query = "SELECT ID, Name, BrandID FROM Beer";
            SqlCommand command = new SqlCommand(Query, _connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                string Nombre = reader.GetString(1);
                int BrandID = reader.GetInt32(2);
                Cervezas.Add(new Beer(ID, Nombre, BrandID));
            }

            Close();

            return Cervezas;
        }
        #endregion

        #region Insertar
        public void Add(Beer beer)
        {
            Connect();
            string Query = "INSERT INTO Beer (Name,BrandID) " +
                "VALUES (@name,@brandid)";
            SqlCommand command = new SqlCommand(Query, _connection);
            command.Parameters.AddWithValue("@name", beer.Name);
            command.Parameters.AddWithValue("@brandid", beer.BrandID);
            command.ExecuteNonQuery();
            Close();
        } 
        #endregion

        #region Editar
        public Beer Get(int id)
        {
            Connect();
            Beer cerveza = null;
            string query = "SELECT ID, Name, BrandID FROM Beer " +
                "WHERE ID = @id";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(1);
                int brandid = reader.GetInt32(2);
                cerveza = new Beer(id, name, brandid);
            }

            Close();
            return cerveza;
        }

        public void Edit(Beer beer)
        {
            Connect();

            string query = "UPDATE  Beer  SET Name = @name, BrandID = @brandid " +
                "WHERE ID = @id";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", beer.Name);
            command.Parameters.AddWithValue("@brandid", beer.BrandID);
            command.Parameters.AddWithValue("@id", beer.ID);
            command.ExecuteNonQuery();

            Close();
        }
        #endregion

        #region Eliminar
        public void Delete(int id)
        {
            Connect();
            string query = "DELETE  FROM Beer WHERE ID = @id";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            Close();
        } 
        #endregion
    }
}
