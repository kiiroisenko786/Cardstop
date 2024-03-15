using Cardstop.DataAccess.Repository.iRepository;
using Cardstop.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cardstop.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly iUnitOfWork _unitOfWork;
        public ShoppingCartViewComponent(iUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            // if user is logged in (null claim == no user id)
            if (claim != null)
            {
                // Check if a session doesn't exist
                if (HttpContext.Session.GetInt32(SD.SessionCart) == null)
                {
                    // Then we set the session
                    HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).Count());
                }
                
                // Else return whatever is set in the session directly
                return View(HttpContext.Session.GetInt32(SD.SessionCart));
            } else
            {
                // On clear the basket will be 0, so we can just return 0
                HttpContext.Session.Clear();
                return View(0);
            }
        }
    }
}
