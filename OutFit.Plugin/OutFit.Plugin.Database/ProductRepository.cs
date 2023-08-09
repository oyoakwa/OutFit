using Microsoft.EntityFrameworkCore;
using OutFit.CoreBusiness;
using OutFit.UseCases.PluginInterfaces;
using OutFit.CoreBusiness.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.Plugin.Database
{
    public class ProductRepository : IProductRepository
    {
        private readonly OutFitDbContext _repo;
        public ProductRepository(OutFitDbContext repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }   
        public  Task AddProductAsync(Product product)
        {
            var prod = _repo.product.FirstOrDefault(p => p.Name.ToLower().Equals(product.Name.ToLower()) && p.Size.Equals(product.Size) && p.Colour.ToLower().Equals(product.Colour.ToLower()));
            if (prod != null)
            {
                prod.Quantity += prod.Quantity;
                return Task.CompletedTask;
            }
            _repo.product.Add(product);
            
            _repo.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(_repo.product.ToList().Where(p=>p.Quantity > 0).ToList());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _repo.product.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null) {
                throw new NullReferenceException(nameof(product));
            }
            return product;
        }
    }
}
