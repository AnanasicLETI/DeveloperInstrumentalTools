using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorWebApplication.Models;
using RazorWebApplication.Services;

namespace RazorWebApplication.Controllers
{
    public class AdvertsController : Controller
    {
        private IAdvertsService AdvertsService { get; }
        
        public AdvertsController(IAdvertsService advertsService)
        {
            AdvertsService = advertsService;
        }

        public async Task<IActionResult> Index()
        {
            return this.View(await this.AdvertsService.GetAdverts());
        }

        public IActionResult Details(Adverts model)
        {
            return this.View(model);
        }
    }
}