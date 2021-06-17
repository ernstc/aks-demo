using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApp2.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public virtual Country Country { get; set; }
    }
}
