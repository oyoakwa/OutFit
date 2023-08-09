using OutFit.CoreBusiness;
using OutFit.UseCases.PluginInterfaces;
using OutFit.UseCases.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.UseCases.Products
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository _productRepository;
        public AddProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddProductAsync(product);
        }
    }
}
