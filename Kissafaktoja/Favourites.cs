using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kissafaktoja
{
    internal class Favourites
    {
         static List<string> listFavouriteCatFacts = new List<string>();

        public static void addFavouriteCatFact(string fact)
        {
            
            listFavouriteCatFacts.Add(fact);
            Debug.WriteLine("number of favourites: " + listFavouriteCatFacts.Count);
        }

        public static List<string> getListOfFavourites()
        {
            return listFavouriteCatFacts;
        }

        public static void clearFavs()
        {
            listFavouriteCatFacts.Clear();
        }
    }
}
