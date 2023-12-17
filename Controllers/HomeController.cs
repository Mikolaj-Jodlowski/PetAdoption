using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetAdoption.Models;
using System.Threading.Tasks;
using Contentful.Core;
using System.Linq;

namespace PetAdoption.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContentfulClient _client;

        public HomeController(ILogger<HomeController> logger, IContentfulClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var pets = await _client.GetEntriesByType<Pet>("petAdoption");
            return View(pets);
        }

        public async Task<IActionResult> Formula()
        {
            var formulaData = await _client.GetEntriesByType<Pet>("petAdoption");
            return View(formulaData);
        }

        public async Task<IActionResult> Pets()
        {
            var pets = await _client.GetEntriesByType<Pet>("petAdoption");
            return View(pets);
        }
    }
}
