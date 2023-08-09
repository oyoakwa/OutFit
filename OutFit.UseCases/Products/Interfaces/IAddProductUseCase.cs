using OutFit.CoreBusiness;

namespace OutFit.UseCases.Products.Interfaces
{
    public interface IAddProductUseCase
    {
        Task AddProductAsync(Product product);
    }
}