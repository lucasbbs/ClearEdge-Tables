using ClearEdge_Tables.Models;
using ClearEdge_Tables.Models.ViewModels;
using ClearEdge_Tables.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace ClearEdge_Tables.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string searchString, string category)
        {
            List<string> categoryQuery = _unitOfWork.Table.ListAll()
                .Select(obj => obj.Category).ToList();
            IEnumerable<Table> tableList = _unitOfWork.Table.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                tableList = tableList.Where(s => s.Name!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(category))
            {
                tableList = tableList.Where(x => x.Category == category);
            }

            var tableCategoryVM = new TableCategoryViewModel
            {
                Categories = new SelectList(categoryQuery),
                Tables = tableList
            };
            return View(tableCategoryVM);
        }

        public IActionResult Details(int tableId)
        {
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                Table = _unitOfWork.Table.Get(u => u.Id == tableId),
                Count = 1,
                TableId = tableId
            };
            return View(shoppingCart);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.CustomerId = userId;
            var totalShoppingCardsRecord = _unitOfWork.ShoppingCart.GetAll().Count();
            shoppingCart.Id = totalShoppingCardsRecord + 1;

            ShoppingCart shoppingCartFromDatabase = _unitOfWork.ShoppingCart.Get(s => s.CustomerId == userId && s.TableId == shoppingCart.TableId);

            if(shoppingCartFromDatabase != null)
            {
                shoppingCartFromDatabase.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(shoppingCartFromDatabase);
            }
            else
            {
                _unitOfWork.ShoppingCart.Add(shoppingCart);
            }

            _unitOfWork.Save();
            return RedirectToAction("Index");
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
    }
}
