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
    public class AddToCartUseCase : IAddToCartUseCase
    {
        private readonly ICartRepository _cartRepository;
        public AddToCartUseCase(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task AddToCartAsync(Cart Cart)
        {
            await _cartRepository.AddCartAsync(Cart);
        }
    }
}
