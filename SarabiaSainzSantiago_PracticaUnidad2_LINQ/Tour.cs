using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarabiaSainzSantiago_PracticaUnidad2_LINQ
{
    public class Tour
    {
        public string TourCode { get; set; }
        public string TourName { get; set; }
        public string Responsible { get; set; }

        public Tour(string tourCode, string tourName, string responsible)
        {
            this.TourName = tourName;
            this.TourCode = tourCode;
            this.Responsible = responsible;
        }
    }
}
