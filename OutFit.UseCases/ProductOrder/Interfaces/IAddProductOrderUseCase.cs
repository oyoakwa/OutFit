using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.UseCases.ProductOrder.Interfaces
{
    public interface IAddProductOrderUseCase
    {
        Task AddProductOrderAsync(IList<OutFit.CoreBusiness.ProductOrder> productOrders);
    }
}
