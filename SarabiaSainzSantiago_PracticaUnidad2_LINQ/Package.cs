using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarabiaSainzSantiago_PracticaUnidad2_LINQ
{
    public class Package
    {
        public int PackageCode { get; set; }
        public string PackageName { get; set; }

        public Package(int packageCode, string packageName)
        {
            this.PackageName = packageName;
            this.PackageCode = packageCode;
        }
    }
}
