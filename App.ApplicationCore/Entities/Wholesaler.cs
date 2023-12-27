using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Entities
{
    public class Wholesaler
    {
        public int WholesalerId { get; set; }
        public string Name { get; set; }


        // Navigation properties for related entities
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
