using OutFit.CoreBusiness;
using OutFit.UseCases.Carts.Interfaces;
using OutFit.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.UseCases.Carts
{
    public class ViewCartUseCase : IViewCartUseCase
    {
        private readonly ICartRepository _cartRepository;
        public ViewCartUseCase(ICartRepository cartRepository)
        {

            _cartRepository = cartRepository;

        }

        public async Task<IEnumerable<Cart>> ViewCartAsync()
        {
             return await _cartRepository.GetCartAsync();
        }
    }
}
