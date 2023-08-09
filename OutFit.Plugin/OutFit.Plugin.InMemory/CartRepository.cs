using OutFit.CoreBusiness;
using OutFit.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.Plugin.InMemory
{
    public class CartRepository : ICartRepository
    {
        private List<Cart> _carts = new List<Cart>();
        public CartRepository()
        {
            
        }
        public Task AddCartAsync(Cart cart)
        {
            var crt = _carts.FirstOrDefault(x => x.ProductId == cart.ProductId);
            if (crt != null)
            {
                crt.Quantity += 1;
                return Task.CompletedTask;
            }
            _carts.Add(cart);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Cart>> GetCartAsync()
        {
            return await Task.FromResult(_carts);
        }
    }
}
