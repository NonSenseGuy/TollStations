using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollStations.Model
{
    class Toll
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UpdateDate { get; set; }

        public Toll(int _lat, int _long, string _name, string _description, string _updateDate)
        {
            Latitude = _lat;
            Longitude = _long;
            Name = _name;
            Description = _description;
            UpdateDate = _updateDate;
        }


    }
}
