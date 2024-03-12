using Cardstop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardstop.DataAccess.Repository.iRepository
{
    public interface iOrderHeaderRepository : iRepository<OrderHeader>
    {
        void Update(OrderHeader obj);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
        void UpdateStripePayment(int id, string sessionId, string paymentIntentId);
    }
}
