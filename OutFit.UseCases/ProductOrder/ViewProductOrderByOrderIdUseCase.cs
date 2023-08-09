using OutFit.UseCases.PluginInterfaces;
using OutFit.UseCases.ProductOrder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.UseCases.ProductOrder
{
    public class ViewProductOrderByOrderIdUseCase : IViewOrderedProductsByOrderIdUseCase
    {
        private readonly IProductOrderRepository _repo;
        public ViewProductOrderByOrderIdUseCase(IProductOrderRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<CoreBusiness.ProductOrder>> ViewProductOrderByOrderId(int orderId)
        {
            var result = await _repo.GetProductOrderByOrderId(orderId);
            return result;
        }
    }
}
