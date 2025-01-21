using DataLayer.Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubscriptionService( IUnitOfWork unitOfWork) { 
            _unitOfWork = unitOfWork;
            
        }


        public async Task<bool> AddSubscription(Subscription subscription)
        {
            var result = await _unitOfWork.SubscriptionRepository.AddSubscription(subscription);

            return result;
        }
    }
}
