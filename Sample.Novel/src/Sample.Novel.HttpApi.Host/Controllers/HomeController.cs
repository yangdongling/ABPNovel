using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Sample.Novel.HttpApi.Host.Controllers
{
    public class HomeController : AbpController
    {
        // GET
        public IActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}