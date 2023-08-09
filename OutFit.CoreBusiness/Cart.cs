using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.CoreBusiness
{
    [Serializable]
    public class Cart
    {
        [Key]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public Product Product { get; set; } = new Product();
    }
}
