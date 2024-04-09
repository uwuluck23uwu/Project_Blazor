using WebLucky_Client.ViewModels;

namespace WebLucky_Client.Service.IService
{
    public interface ICartService
    {
        Task DecrementCart(ShoppingCart shoppingCart);
        Task IncrementCart(ShoppingCart shoppingCart);
        public event Action OnChange;
    }
}
