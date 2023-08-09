using OutFit.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.UseCases.Orders.Interfaces
{
    public interface IViewOrderUseCase
    {
        Task<IEnumerable<Order>> ViewOrderAsync();
    }
}
