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
    public class OrderRepository : IOrderRepository
    {
        private readonly OutFitDbContext _repo;

        public OrderRepository(OutFitDbContext repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }
        public Order AddOrderAsync(Order order)
        {
            _repo.Order.Add(order);
            _repo.SaveChanges();
//Changing the Id to Guid will enable me display the inserted order without consulting the database, which will be much faster
            return _repo.Order.Where(o=>o==order).FirstOrDefault();
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
