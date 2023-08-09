using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.CoreBusiness
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; }
        public decimal OrderPrice { get; set; }
        public string? ShippedToLocation { get; set; }
        public string? ReceiversPhoneNumber { get; set;}
        public string? ReceiversName { get; set; }
        public string? OrderNote { get; set;}
    }
}
