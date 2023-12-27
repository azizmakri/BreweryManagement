using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Entities
{
    public class Brewery
    {
        public int BreweryId { get; set; }

        public string Name { get; set; }
        // Navigation property for related Beers

        public virtual ICollection<Beer> Beers { get; set; }


    }
}
