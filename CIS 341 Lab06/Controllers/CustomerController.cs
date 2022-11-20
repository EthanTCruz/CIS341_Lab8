using Microsoft.AspNetCore.Mvc;
using CIS_341_Lab06.Data;
using CIS_341_Lab06.Models;
using CIS_341_Lab06.Models.DTO;

namespace CIS_341_Lab06.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CommunityStoreContext _context;

        public CustomerController(CommunityStoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubmitListing()
        {
            return View();
        }



    }
}
