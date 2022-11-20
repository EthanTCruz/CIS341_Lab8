using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using CIS_341_Lab06.Data;
using CIS_341_Lab06.Models;
using CIS_341_Lab06.Models.DTO;

namespace CIS_341_Lab06.Controllers
{
    public class HomeController : Controller
    {
        private readonly CommunityStoreContext _context;


        public HomeController(CommunityStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Listing> listings = await _context.Listings
                .Include(listing => listing.Condition)
                .Include(listing => listing.Store)
                .ToListAsync();

            foreach (Listing listing in listings)
            {

                await _context.Entry(listing).Reference(l => l.Customer).LoadAsync();
            }

            List<ListingDTO> listDTOs = new();
            foreach (Listing l in listings)
            {
                ListingDTO listingDTO = new()
                { 
                    ListingID = l.ListingID,
                    Quantity = l.Quantity,
                    Description = l.Description,
                    Customer = l.Customer.FirstName + " " + l.Customer.LastName,
                    Store = l.Store.Name,
                    Condition = l.Condition.Description
                };
                listDTOs.Add(listingDTO);
            }

            return View(listDTOs);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Claim_Unclaim(int id, [Bind("ListingID")] ListingDTO listing)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var null_customer = await _context.Customers
.FirstOrDefaultAsync(l => l.FirstName == "Null");
                    var actual_customer = await _context.Customers
.FirstOrDefaultAsync(l => l.FirstName == "Ethan");
                    var entity = await _context.Listings
                        .FirstOrDefaultAsync(l => l.ListingID == id);
                if (entity.CustomerID == null || entity.CustomerID==null_customer.CustomerID)
                    {
                        //actual_customer will be replaced by actually customer id later
                        entity.CustomerID = actual_customer.CustomerID;
                    }
                else
                    {

                        entity.CustomerID = null_customer.CustomerID;
                    }
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Listings.Any(e => e.ListingID == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Home/Index");
            }
            return Redirect("/Home/Index");
        }

    }
}