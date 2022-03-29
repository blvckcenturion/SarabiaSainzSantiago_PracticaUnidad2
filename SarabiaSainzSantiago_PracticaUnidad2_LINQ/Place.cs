using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarabiaSainzSantiago_PracticaUnidad2_LINQ
{
    public class Place
    {
        public string PlaceCode { get; set; }
        public string PlaceName { get; set; }
        public int Package { get; set; }

        public Place(string placeCode, string placeName, int package)
        {
            this.PlaceName = placeName;
            this.PlaceCode = placeCode;
            this.Package = package;
        }
    }
}
