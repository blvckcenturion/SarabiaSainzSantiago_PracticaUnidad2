using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarabiaSainzSantiago_PracticaUnidad2_LINQ
{
    public class Tourist_Place
    {
        public int ID { get; set; }
        public string PlaceId { get; set; }

        public Tourist_Place(int id, string placeId)
        {
            this.ID = id;
            this.PlaceId = placeId;
        }


    }
}
