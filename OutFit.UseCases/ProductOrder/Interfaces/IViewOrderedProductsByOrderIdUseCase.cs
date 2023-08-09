using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.UseCases.ProductOrder.Interfaces
{
    public interface IViewOrderedProductsByOrderIdUseCase
    {
        Task<IEnumerable<CoreBusiness.ProductOrder>> ViewProductOrderByOrderId(int orderId);
    }
}
