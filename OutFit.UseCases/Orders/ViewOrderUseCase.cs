using OutFit.CoreBusiness;
using OutFit.UseCases.Carts.Interfaces;
using OutFit.UseCases.Orders.Interfaces;
using OutFit.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.UseCases.Orders
{
    public class ViewOrderUseCase : IViewOrderUseCase
    {
        private readonly IOrderRepository _order;

        public ViewOrderUseCase(IOrderRepository order)
        {
            _order = order;
        }

        public async Task<IEnumerable<Order>> ViewOrderAsync()
        {
            return await _order.GetAllAsync();
        }
    }
}
