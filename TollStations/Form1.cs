using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TollStations.Model;

namespace TollStations
{
    public partial class MainWindow : Form
    {
        private Country country;

        public MainWindow()
        {
            InitializeComponent();
            country = new Country("Colombia");
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(3.900749, -73.073215);
        }

        private void gmap_Load(object sender, EventArgs e)
        {
            
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            foreach (Toll t in country.TollStations)
            {
                Console.WriteLine(t.Latitude + " , " + t.Longitude);
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(t.Latitude, t.Longitude),
                  GMarkerGoogleType.green);
                marker.ToolTipText = t.Price + " $ \n " + t.Name + "\n" + t.Description + "\n" +t.Latitude + " , " + t.Longitude;
                
                markersOverlay.Markers.Add(marker);
                
            }
            gmap.Overlays.Add(markersOverlay);
            /**
            Toll t = country.TollStations[0];
            GMapOverlay markersOverLay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(t.Latitude, t.Longitude),GMarkerGoogleType.green);
            markersOverLay.Markers.Add(marker);
            gmap.Overlays.Add(markersOverLay);
        **/


        }
    }
}
