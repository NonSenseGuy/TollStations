using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollStations.Model
{
    static class Cleaner
    {
        public static void RemoveLine(double latitude, double longitude)
        {
            StreamReader sr = new StreamReader("../../../resources/Estaciones_de_peaje.csv");
            StreamWriter sw = new StreamWriter("../../../resources/EstacionesdePeaje.csv");
            string line;
            while((line = sr.ReadLine()) != null)
            {
                string[] values = line.Split(',');
                
                sw.WriteLine(line);
            }
        }
    }
}
