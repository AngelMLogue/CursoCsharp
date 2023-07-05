using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos
{
    public class Beer
    {
        public int ID { get; set; }
        public string Name { get; set; }   
        public int BrandID { get; set; }

        public Beer(int ID, string Name, int BrandID)
        {
            this.ID = ID;
            this.Name = Name;
            this.BrandID = BrandID;
        }

        public Beer(string Name, int BrandID)
        {
            this.Name = Name;
            this.BrandID = BrandID;
        }
    }
}
