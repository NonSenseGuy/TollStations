using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollStations.Model
{
    class Country
    {
        public string Name { get; set; }
        public List<Toll> TollStations { get; set; }

        public Country(string _name)
        {
            Name = _name;
            LoadTollStations();
        }

        public void LoadTollStations()
        {
            List<Toll> auxTolls = new List<Toll>();
            StreamReader sr = new StreamReader("../../resources/Tabla_de_Costos_de_Peajes.csv");
            string line;
            sr.ReadLine(); // Skips first line of the csv file 
            while((line = sr.ReadLine()) != null)
            {
                string[] values = line.Split(',');
                int latitude = ToInteger(values[2]);
                int longitude = ToInteger(values[3]);
                string name = values[4];
                string description = values[5];
                string updateDate = values[6];
                Toll t = new Toll(latitude, longitude, name, description, updateDate);
            }
        }

        public int ToInteger(string intString)
        {
            if (!Int32.TryParse(intString, out int i))
            {
                i = -1;
            }
            return i;
        }
    }
}
