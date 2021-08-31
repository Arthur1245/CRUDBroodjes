using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDBroodjes.Models
{
    public class Bestelling
    {
        public int Id { get; set; }



        //string want met een double  wanneer ik een nieuw broodje aanmaak met een kommagetal dan laat het geen punt zien daarna. bv als ik 3.60 als prijs zet dan laat het daarna zien als 360


        public IList<Broodje> Broodjes { get; set; }

        public int PersoonID { get; set; }
        public Persoon Persoon { get; set; }

        public int BroodjeID { get; set; }
        public Broodje Broodje { get; set; }
    }
}
