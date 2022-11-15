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
        public static List<string> listFavouriteCatFacts = new List<string>();

        //TODO: add a page to view favourites.

        public static void addFavouriteCatFact(string fact)
        {
            listFavouriteCatFacts.Add(fact);
            Debug.WriteLine("number of favourites: " + listFavouriteCatFacts.Count);
        }
    }
}
