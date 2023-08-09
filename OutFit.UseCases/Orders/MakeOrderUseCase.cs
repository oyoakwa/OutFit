using OutFit.CoreBusiness;
using OutFit.UseCases.Orders.Interfaces;
using OutFit.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.UseCases.Orders
{
    public class MakeOrderUseCase : IMakeOrderUseCase
    {
        private readonly IOrderRepository _order;

        public MakeOrderUseCase(IOrderRepository order)
        {
            _order = order;
        }
        public Order MakeOrderAsync(Order order)
        {
             var v =_order.AddOrderAsync(order);
            return v;
        }
    }
}
