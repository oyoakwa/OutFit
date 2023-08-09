using OutFit.UseCases.PluginInterfaces;
using OutFit.UseCases.ProductOrder.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.UseCases.ProductOrder
{
    public class AddProductOrderUseCase : IAddProductOrderUseCase
    {
        private readonly IProductOrderRepository _repo;
        public AddProductOrderUseCase(IProductOrderRepository repo)
        {
            _repo = repo;
        }
        public async Task AddProductOrderAsync(IList<CoreBusiness.ProductOrder> productOrders)
        {
            await _repo.AddProductOrderAsync(productOrders);
        }
    }
}
