using OutFit.CoreBusiness;
using OutFit.CoreBusiness.Data;
using OutFit.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.Plugin.Database
{
    public class ProductOrderRepository : IProductOrderRepository
    {
        private readonly OutFitDbContext _repo;
        public ProductOrderRepository(OutFitDbContext repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));   
        }
        public async Task AddProductOrderAsync(IList<ProductOrder> productOrder)
        {
            await _repo.productorder.AddRangeAsync(productOrder);
            
            _repo.SaveChanges();
        }

        public async Task<IEnumerable<ProductOrder>> GetProductOrderByOrderId(int orderId)
        {
            var result = _repo.productorder.Where(po => po.orderid == orderId).ToList();
            return await Task.FromResult( result.AsEnumerable<ProductOrder>());
        }
    }
}
