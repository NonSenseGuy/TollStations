using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollStations.Model
{
    class Toll
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UpdateDate { get; set; }
        public int Price { get; set; }

        public Toll(double _lat, double _long, string _name, string _description, string _updateDate, int _price)
        {
            Latitude = _lat;
            Longitude = _long;
            Name = _name;
            Description = _description;
            UpdateDate = _updateDate;
            Price = _price;
        }


    }
}
