using OutFit.CoreBusiness;
using OutFit.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.Plugin.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;
        public ProductRepository() 
        { 
            _products = new List<Product>()
            {
                new Product{ Id=1, Name="LondonBoot", Type=1, brand="Prada", Price=12000,Description="London boot for the Snows", Quantity=10},
                new Product{ Id=2, Name="Toms", Type=1, brand="Tombs",Size="43", Price=12000,Description="Light Easy wears", Quantity=10},
                new Product{ Id=3, Name="Loffas", Type=1, brand="Nike",Size="43", Price=13000,Description="Smart, tough and easy", Quantity=10},
                new Product{ Id=4, Name="Sandals", Type=1, brand="Kito",Size="43", Price=10000,Description="Easy Wears", Quantity=10},
                new Product{ Id=5, Name="Timberland", Type=1, brand="LV",Size="43", Price=22000,Description="Classic and Elegant", Quantity=10} 
            };
        }

        public Task AddProductAsync(Product product)
        {
            var prod = _products.FirstOrDefault(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase) && x.Size.Equals(product.Size, StringComparison.OrdinalIgnoreCase));
            if (prod != null)
            {
                prod.Quantity += prod.Quantity;
                return Task.CompletedTask;
            }
            var maxId = _products.Max(x => x.Id);
            product.Id = maxId + 1;
            _products.Add(product);
            return Task.CompletedTask;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(_products.Where(p => p.Quantity > 0).ToList()) ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
