using OutFit.CoreBusiness;

namespace OutFit.UseCases.Carts.Interfaces
{
    public interface IViewCartUseCase
    {
        Task<IEnumerable<Cart>> ViewCartAsync();
    }
}