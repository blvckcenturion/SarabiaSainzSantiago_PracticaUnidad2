using System;

namespace SarabiaSainzSantiago_PracticaUnidad2_LINQ
{
    class MainClass
    {
        
        static Tourist[] tourists = {
                new Tourist(123, "Elias Andrade", "TA", 4),
                new Tourist(234, "Moira Alen", "TA", 2),
                new Tourist(345, "Lony Labbe", "TG", 8),
                new Tourist(456, "Sidney Sommer", "TA", 3),
                new Tourist(567, "Ari Hass", "TG", 8),
                new Tourist(678, "Rita Asis", "TC", 5),
                new Tourist(789, "Marco Esteves", "TA", 3),
                new Tourist(890, "Julia Lang", "TG", 6),
                new Tourist(901, "Ingrid RamosAsis", "TC", 5),
                new Tourist(012,"Erick Kolbe","TP",1),
            };

        static Tour[] tours = {
                new Tour("TA","Turismo Aventura","Magic Tours"),
                new Tour("TG","Turismo Gastronómico","Turismo Kronos"),
                new Tour("TC","Turismo Compras","Eva's Tours Co."),
                new Tour("TP","Turismo Paseos","Alex Tours")
            };

        static Place[] places = {
                 new Place("PV","Puerto Varas",4),
                 new Place("BRLCH","Bariloche",3),
                 new Place("BRA","Rio de Janeiro",3),
                 new Place("CHLT","Chalten",1),
                 new Place("PA","Punta Arenas",5),
                 new Place("PN","Puerto Natales",8),
                 new Place("VAL","Valdivia",6),
                 new Place("BA","Buenos Aires",2),
                 new Place("SP","San Pablo",1),
                 new Place("FLO","Florianópolis",2)
            };

        static Tourist_Place[] tourist_place = {
                 new Tourist_Place(123,"BRLCH"),
                 new Tourist_Place(123,"PV"),
                 new Tourist_Place(123,"BRA"),
                 new Tourist_Place(123,"FLO"),
                 new Tourist_Place(234,"SP"),
                 new Tourist_Place(234,"BA"),
                 new Tourist_Place(345,"PN"),
                 new Tourist_Place(345,"VAL"),
                 new Tourist_Place(456,"BRA"),
                 new Tourist_Place(456,"BA"),
                 new Tourist_Place(567,"PN"),
                 new Tourist_Place(678,"PA"),
                 new Tourist_Place(678,"PV"),
                 new Tourist_Place(789,"BRA"),
                 new Tourist_Place(789,"SP"),
                 new Tourist_Place(789,"FLO"),
                 new Tourist_Place(890,"VAL"),
                 new Tourist_Place(890,"BRLCH"),
                 new Tourist_Place(901,"PA"),
                 new Tourist_Place(012,"CHLT")
            };

        static Package[] packages = {
                 new Package(1,"Básico"),
                 new Package(2,"Económico"),
                 new Package(3,"Estandar"),
                 new Package(4,"Jubilados"),
                 new Package(5,"Familiar"),
                 new Package(6,"Todo incluido"),
                 new Package(7,"Extra"),
                 new Package(8,"Vip")
            };

        static string[] options =
        {
                "1.Listar todos los turistas agrupados por tour.",
                "2.Dado el nombre de un lugar, listar los nombres de los turistas que visitarán ese lugar.",
                "3.Dado el nombre de un paquete indicar que lugares son visitados con ese paquete.",
                "4.Dado un turista mostrar el nombre del responsable de su tour.",
                "5.Mostrar los nombres de turistas junto a su responsable de tour.",
                "6.Mostrar los turistas por cada lugar a visitar:",
                "7.Cantidad de turistas que habrá en cada lugar a visitar.",
                "8.Nombres de turistas agrupados por(nombre de) paquete.",
                "9.Turistas registrados en más de un paquete.",
                "10.Mostrar la cantidad de turistas por cada tour en forma descendente.",
                
            };
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Escoja un inciso");
            foreach(string s in options) Console.WriteLine(s);
            int res = -1;
            bool valid = int.TryParse(Console.ReadLine(), out res);
            if (!valid || res < 1 || res > 11) 
            {
                Console.Clear();
                Main(args);
                return;
            }
            
            Console.Clear();
            Console.WriteLine(options[res-1]);
            switch (res)
            {
                case 1:
                    Exercise1();
                    break;
                case 2:
                    Exercise2();
                    break;
                case 3:
                    Exercise3();
                    break;
                case 4:
                    Exercise4();
                    break;
                case 5:
                    Exercise5();
                    break;
                case 6:
                    Exercise6();
                    break;
                case 7:
                    Exercise7();
                    break;
                case 8:
                    Exercise8();
                    break;
                case 9:
                    Exercise9();
                    break;
                case 10:
                    Exercise10();
                    break;
            }

            Console.WriteLine("Deseas salir de la ejecucuion? (y/n)");
            string ans = Console.ReadLine();
            if(ans.ToLower() != "y")
            {
                Console.Clear();
                Main(args);
            }
        }

        static void Exercise1()
        {
            var groupedTourists = from t in tourists
                                  join tr in tours on t.TourCode equals tr.TourCode
                                  group t by tr.TourName;
            foreach (var t in groupedTourists)
            {
                Console.WriteLine("Touristas agrupados por tour:" + t.Key + "\n");
                foreach (var p in t)
                    Console.WriteLine("ID: " + p.ID + " | Nombre: " + p.Name + "| Codigo Tour: " + p.TourCode);
                Console.WriteLine("\n");
            }
        }

        static void Exercise2()
        {
            Console.WriteLine("Posibles Destinos: ");
            foreach (var pl in places) Console.WriteLine(pl.PlaceName);
            Console.WriteLine("Indica el lugar de destino");
            string place = Console.ReadLine();
            if (Array.FindIndex(places, p => p.PlaceName.ToLower() == place.ToLower()) != -1)
            {
                var destinationCode = (from p in places
                                       where p.PlaceName.ToLower() == place.ToLower()
                                       select p.PlaceCode).FirstOrDefault();
                var touristPlace = from t in tourists
                                   join tp in tourist_place on t.ID equals tp.ID
                                   join pl in places on tp.PlaceId equals pl.PlaceCode
                                   where pl.PlaceName.ToLower() == place.ToLower()
                                   select new { Name = t.Name, ID = t.ID, Destiny = pl.PlaceName };

                Console.WriteLine("Destino: " + place + "Codigo: " + destinationCode);
                foreach (var tp in touristPlace) Console.WriteLine("ID :" + tp.ID + " | Nombre: " + tp.Name);
            }
            else
            {
                Console.WriteLine("Destino invalido.");
                Exercise2();
            }
        }

        static void Exercise3()
        {
            Console.WriteLine("Posibles Paquetes:");
            foreach (var pk in packages) Console.WriteLine(pk.PackageName);
            string pkg = Console.ReadLine();
            if (Array.FindIndex(packages, p => p.PackageName.ToLower() == pkg.ToLower()) != -1)
            {
                var visitedDestinations = from p in places
                                          join pack in packages on p.Package equals pack.PackageCode
                                          where pack.PackageName.ToLower() == pkg.ToLower()
                                          select p;
                Console.WriteLine("Paquete: " + pkg);
                foreach (var p in visitedDestinations) Console.WriteLine("Codigo destino: " + p.PlaceCode + " | Nombre destino: " + p.PlaceName + " | Paquete: " + p.Package);
            }
            else
            {
                Console.WriteLine("Paquete Invalido.");
                Exercise3();
            }
        }

        static void Exercise4()
        {
            Console.WriteLine("Posibles Turistas");
            foreach (var tr in tourists) Console.WriteLine(tr.Name);
            string trName = Console.ReadLine();
            if (Array.FindIndex(tourists, tr => tr.Name.ToLower() == trName.ToLower()) != -1)
            {
                var tourData = (from t in tourists
                                join tr in tours on t.TourCode equals tr.TourCode
                                where t.Name.ToLower() == trName.ToLower()
                                select new { Responsible = tr.Responsible, TourName = tr.TourName }).FirstOrDefault();
                Console.WriteLine("Responsable del tour " + tourData.TourName + " donde se encuentra " + trName + " :");
                Console.WriteLine(tourData.Responsible);
            } else
            {
                Console.WriteLine("Turista Invalido.");
                Exercise4();
            }
        }

        static void Exercise5()
        {
            var touristsData = from t in tourists
                           join tr in tours on t.TourCode equals tr.TourCode
                           orderby tr.TourCode descending
                           select new { Responsible = tr.Responsible, ID = t.ID, Name = t.Name,};
            foreach (var t in touristsData) Console.WriteLine("ID: " + t.ID + " | Nombre " + t.Name + " | Responsable:" + t.Responsible);
        }

        static void Exercise6()
        {
            var groupedTourists = from t in tourists
                                  join tp in tourist_place on t.ID equals tp.ID
                                  join p in places on tp.PlaceId equals p.PlaceCode
                                  group t by p.PlaceName;
            foreach (var t in groupedTourists)
            {
                Console.WriteLine("Touristas agrupados por lugar:" + t.Key + "\n");
                foreach (var p in t)
                    Console.WriteLine("ID: " + p.ID + " | Nombre: " + p.Name + "| Codigo Tour: " + p.TourCode);
                Console.WriteLine("\n");
            }
        }

        static void Exercise7()
        {
            var groupedTourists = from t in tourists
                                  join tp in tourist_place on t.ID equals tp.ID
                                  join p in places on tp.PlaceId equals p.PlaceCode
                                  group t by p.PlaceName;
            foreach (var t in groupedTourists) Console.WriteLine("Cantidad de Touristas agrupados por lugar:" + t.Key + " | Cantidad: " + t.Count() + "\n");

            // Otra solucion basada en los registros almacenados en tourist_place
            //var groupedTourists2 = from tp in tourist_place
            //                       group tp by tp.PlaceId;
            //foreach (var t in groupedTourists2)
            //{
            //    Console.WriteLine("Cantidad de Touristas agrupados por lugar:" + t.Key);
            //    Console.WriteLine(t.Count());
            //}
        }
        static void Exercise8()
        {
            var groupedTourists = from t in tourists
                                  join p in packages on t.PackageCode equals p.PackageCode
                                  group t by p.PackageName;
            foreach (var t in groupedTourists)
            {
                Console.WriteLine("Turistas agrupados por nombre de paquete:" + t.Key + "\n");
                foreach (var p in t)
                    Console.WriteLine("ID: " + p.ID + " | Nombre: " + p.Name + "| Codigo Tour: " + p.TourCode);
                Console.WriteLine("\n");
            }
        }
        static void Exercise9()
        {
            // Debido a que no existe ningun turista con mas de 1 paquete, realizo lo opuesto: cantidad de turistas registrados en mas de 1 paquete
            var groupedTourists = from t in tourists
                                  join pk in packages on t.PackageCode equals pk.PackageCode
                                  group t by pk.PackageName into grouped
                                  where grouped.Count() > 1
                                  select new {Count= grouped.Count(), Key = grouped.Key};
            Console.WriteLine("Paquetes con mas de un turista registrado");
            foreach(var t in groupedTourists)
            {
                Console.WriteLine("Nombre Paquete :" + t.Key + " | Cantidad: " + t.Count);
            }
            // Sin embargo tambien dejo el query que permitiria seleccionar a los turistas que se encuentran en mas de 1 paquete
            var groupedTourists2 = from t in tourists
                                   group t by t.Name into grouped
                                   where grouped.Count() > 1
                                   select new {Count = grouped.Count(), Key = grouped.Key};
            Console.WriteLine("\nTuristas registrados en mas de un paquete");
            foreach (var t in groupedTourists2)
                Console.WriteLine("Nombre: " + t.Key + "| Cantidad Grupos: " + t.Count);
        }
        static void Exercise10()
        {
            var touristsData = from t in tourists
                               join tr in tours on t.TourCode equals tr.TourCode
                               group t by tr.TourCode into tourCount
                               select new { Tour = (from tr in tours where tr.TourCode == tourCount.Key select tr.TourName).FirstOrDefault(), TourCount = tourCount.Count() };
            foreach( var t in touristsData)
            {
                Console.WriteLine("Tour: "+ t.Tour + " | Cantidad: " + t.TourCount);
            }

        }

    }
}