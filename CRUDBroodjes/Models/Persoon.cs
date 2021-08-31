using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDBroodjes.Models
{
    public class Persoon
    {
        public int Id { get; set; }
        public string VoorNaam { get; set; }
        public string AchterNaam { get; set; }
        public string Geslacht { get; set; }
        public DateTime Geboortedatum { get; set; }

        // string om dezelfde reden als bestelling
        public string TotaalPrijs { get; set; }


        public IList<Bestelling> Bestellingen { get; set; }
    }
}
