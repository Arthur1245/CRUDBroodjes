using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDBroodjes.Models
{
    public class Broodje
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        //string om dezelfde reden als bestelling
        public string Prijs { get; set; }
    }
}
