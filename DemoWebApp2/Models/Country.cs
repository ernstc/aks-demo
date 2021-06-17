using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApp2.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Region> Regions { get; set; }
    }
}
