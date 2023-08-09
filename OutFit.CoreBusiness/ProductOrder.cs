using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.CoreBusiness
{
    public class ProductOrder
    {
        public int id { get; set; }
        public int orderid { get; set; }
        public int productid { get; set; }
        public int quantity { get; set; }
    }
}
