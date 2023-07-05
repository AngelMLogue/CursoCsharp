using System.Text.Json;

namespace Json
{
    class Program
    {
        public static void Main(string[] args)
        {
            Cerveza micerveza = new Cerveza()
            { 
                nombre = "Pikantus",
                marca = "Erdinger"
            };

            //string json = "{\"nombre\":\"Pikantus\",\"marca\":\"Erdinger\"}";

            string json = JsonSerializer.Serialize(micerveza);

            Cerveza cerveza = JsonSerializer.Deserialize<Cerveza>(json);

            Cerveza[] cervezas = new Cerveza[] {
                new Cerveza()
                {
                    nombre = "ejemplo1",
                    marca = "marca1"

                },
                new Cerveza()
                {
                    nombre = "ejemplo2",
                    marca = "marca2"
                }
            };

            //string json2 = "["+ "{\"nombre\": \"ejemplo1\",\"marca\": \"marca1\"}," +
            //    "{\"nombre\": \"ejemplo2\",\"marca\": \"marca2\"}"
            //    + "]";

            string json2 = JsonSerializer.Serialize(cervezas);
            Cerveza[] cerveza2 = JsonSerializer.Deserialize<Cerveza[]>(json2);
        }

        public class Cerveza
        {
            public string nombre { get; set; }
            public string marca { get; set; }
        }
    }
}