using OutFit.CoreBusiness;

namespace OutFit.UseCases.Products.Interfaces
{
    public interface IViewProductsUseCase
    {
        Task<IEnumerable<Product>> ViewAllAsync();
    }
}