using Microsoft.AspNetCore.Mvc;

namespace Academix.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected string? GetUserId()
        {
            return User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value;
        }
    }
}
