using OutFit.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutFit.UseCases.Products.Interfaces
{
    public interface IViewProductByIdUseCase
    {
        Task<Product> GetByIdAsync(int id);
    }
}
