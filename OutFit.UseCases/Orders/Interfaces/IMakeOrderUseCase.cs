using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutFit.CoreBusiness;

namespace OutFit.UseCases.Orders.Interfaces
{
    public interface IMakeOrderUseCase
    {
        Order MakeOrderAsync(Order order);
    }
}
