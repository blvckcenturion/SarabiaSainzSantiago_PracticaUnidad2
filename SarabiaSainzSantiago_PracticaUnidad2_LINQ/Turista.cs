using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarabiaSainzSantiago_PracticaUnidad2_LINQ
{
    public class Tourist
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TourCode { get; set; }
        public int PackageCode { get; set; }

        public Tourist(int id, string name, string tourCode, int packageCode)
        {
            this.ID = id;
            this.Name = name;
            this.TourCode = tourCode;
            this.PackageCode = packageCode;
        }
    }
}
