using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialManagementSystem
{
    class Element
    {
        public int MS_ID { get; set; }
        public string Component { get; set; }
        public string Supplier { get; set; }
        public string Config { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int Qty { get; set; }
        public DateTime Purchase_date { get; set; }
        public DateTime Lasteditdate { get; set; }
    }
}
