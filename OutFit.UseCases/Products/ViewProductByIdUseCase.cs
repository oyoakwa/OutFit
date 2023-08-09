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
    public class ViewProductByIdUseCase : IViewProductByIdUseCase
    {
        private readonly IProductRepository _productRepository;
        public ViewProductByIdUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var prod = _productRepository.GetByIdAsync(id);
            return await prod;
        }
    }
}
