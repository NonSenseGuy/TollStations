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
            StreamReader sr = new StreamReader("../../../resources/EstacionesDePeaje.csv");
            string line;
            sr.ReadLine(); // Skips first line of the csv file 
            while((line = sr.ReadLine()) != null)
            {
                string[] values = line.Split(',');
                double latitude = ToDouble(Join(values[2].Split('.'), 1));
                double longitude = ToDouble(Join(values[3].Split('.'), 2));
                string name = values[4];
                string description = values[5];
                string updateDate = values[6];
                int price = ToInteger(values[10]);
                Toll t = new Toll(latitude, longitude, name, description, updateDate, price);
                Console.WriteLine(latitude + ", " + longitude);
                auxTolls.Add(t);
            }
            TollStations = auxTolls;
        }

        public string Join(string[] value, int index)
        {
            string msg = "";
            for (int i = 0; i < value.Length; i++)
            {
                msg += value[i];
            }
            char splitValue = msg.ElementAt(index);
            string[] res = msg.Split(splitValue);
            if(index == 2)
            {
                return res[0] + splitValue + "," + res[1];
            }
            else
            {
                return res[0] + "," + splitValue + res[1];
            }
            
        }

        public int ToInteger(string intString)
        {
            if(!Int32.TryParse(intString, out int i))
            {
                i = -1;
            }
            return i;
        }
        
        public double ToDouble(string doubleString)
        {
            if(!decimal.TryParse(doubleString, out decimal i))
            {
                i = -1;
            }
            double numberAsDouble = ((double)((long)(i * 10000000.0m))) / 10000000.0;
            return numberAsDouble;
        }

    }
}
