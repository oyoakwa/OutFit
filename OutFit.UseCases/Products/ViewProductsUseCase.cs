using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutFit.CoreBusiness;
using OutFit.UseCases.PluginInterfaces;
using OutFit.UseCases.Products.Interfaces;

namespace OutFit.UseCases.Products
{
    public class ViewProductsUseCase : IViewProductsUseCase
    {
        public readonly IProductRepository _productRepo;

        public ViewProductsUseCase(IProductRepository productRepository)
        {
            _productRepo = productRepository;
        }

        public async Task<IEnumerable<Product>> ViewAllAsync()
        {
            return await _productRepo.GetAllAsync();
        }
    }
}
