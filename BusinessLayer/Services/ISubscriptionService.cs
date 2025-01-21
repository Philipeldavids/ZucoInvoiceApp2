using Models;

namespace BusinessLayer.Services
{
    public interface ISubscriptionService
    {
        Task<bool> AddSubscription(Subscription subscription);
    }
}