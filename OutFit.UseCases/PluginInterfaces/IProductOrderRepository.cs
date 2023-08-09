using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.UseCases.PluginInterfaces
{
    public interface IProductOrderRepository
    {
        Task AddProductOrderAsync(IList<CoreBusiness.ProductOrder> productOrder);
        Task<IEnumerable<CoreBusiness.ProductOrder>> GetProductOrderByOrderId(int orderId);
    }
}
