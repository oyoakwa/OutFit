using OutFit.CoreBusiness;

namespace OutFit.UseCases.Carts.Interfaces
{
    public interface IAddToCartUseCase
    {
        Task AddToCartAsync(Cart Cart);
    }
}