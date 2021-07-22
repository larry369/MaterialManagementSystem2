using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialManagementSystem
{
    class SupplierElements
    {
        [DisplayName("廠商編號")]
        public int SupplierID { get; set; }
        [DisplayName("料件")]
        public string Product { get; set; }
    }
}
