using ClearEdge_Tables.Models;
using ClearEdge_Tables.Models.ViewModels;
using ClearEdge_Tables.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClearEdge_Tables.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public ShoppingCartViewModel ShoppingCartViewModel { get; set; }
        public ShoppingCartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartViewModel = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.CustomerId == userId, includeProperties: "Table"),
                Order = new()
            };

            foreach (var shoppingCart in ShoppingCartViewModel.ShoppingCartList)
            {

                shoppingCart.Price = shoppingCart.Table.Price;
                ShoppingCartViewModel.Order.total_amount += shoppingCart.Price * shoppingCart.Count;
            }

            return View(ShoppingCartViewModel);
        }


        public IActionResult Summary() {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartViewModel = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.CustomerId == userId, includeProperties: "Table"),
                Order = new()
            };

            /*           
            ShoppingCartViewModel.Order.Customer = _unitOfWork.Customer.Get(c => c.Id == userId);

            ShoppingCartViewModel.Order.Name = ShoppingCartViewModel.Order.Customer.UserName;
            ShoppingCartViewModel.Order.PhoneNumber = ShoppingCartViewModel.Order.Customer.PhoneNumber;
            ShoppingCartViewModel.Order.StreetAddress = ShoppingCartViewModel.Order.Customer.StreetAddress;
            ShoppingCartViewModel.Order.City = ShoppingCartViewModel.Order.Customer.City;
            ShoppingCartViewModel.Order.State = ShoppingCartViewModel.Order.Customer.State;
            ShoppingCartViewModel.Order.PostalCode = ShoppingCartViewModel.Order.Customer.PostalCode;
            */
            foreach (var shoppingCart in ShoppingCartViewModel.ShoppingCartList)
            {

                shoppingCart.Price = shoppingCart.Table.Price;
                ShoppingCartViewModel.Order.total_amount += shoppingCart.Price * shoppingCart.Count;
            }

            return View(ShoppingCartViewModel);
        }

        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPost()
        {
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			ShoppingCartViewModel.ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.CustomerId == userId, includeProperties: "Table");
			ShoppingCartViewModel.Order.order_date = System.DateTime.Now;
			ShoppingCartViewModel.Order.customerId = userId;

			foreach (var shoppingCart in ShoppingCartViewModel.ShoppingCartList)
			{
				shoppingCart.Price = shoppingCart.Table.Price;
				ShoppingCartViewModel.Order.total_amount += shoppingCart.Price * shoppingCart.Count;
			}
			ShoppingCartViewModel.Order.Status = "Pending";
			ShoppingCartViewModel.Order.PaymentStatus = "Pending";

			if (ShoppingCartViewModel.Order.Name != "" && ShoppingCartViewModel.Order.PhoneNumber != "" && ShoppingCartViewModel.Order.StreetAddress != "" && ShoppingCartViewModel.Order.City != "" && ShoppingCartViewModel.Order.State != "" && ShoppingCartViewModel.Order.PostalCode != ""
			 )
            {
				_unitOfWork.Order.Add(ShoppingCartViewModel.Order);
				HttpContext.Session.SetInt32("SessionShoppingCart",
                _unitOfWork.ShoppingCart.GetAll(u => u.CustomerId == userId).Count());
				_unitOfWork.Save();
				return RedirectToAction("Index");
            }
            return View(ShoppingCartViewModel);
        }
        public IActionResult Plus(int shoppingCartId)
        {
			var shoppingCart = _unitOfWork.ShoppingCart.Get(u => u.Id == shoppingCartId);
            shoppingCart.Count += 1;
            _unitOfWork.ShoppingCart.Update(shoppingCart);
            _unitOfWork.Save();

    //        foreach (var cart in ShoppingCartViewModel.ShoppingCartList)
    //        {
    //            OrderItem orderItem = new()
    //            {
    //                TableId = cart.TableId,
    //                OrderId = ShoppingCartViewModel.Order.Id,
    //                Price = cart.Price,
    //                Count = cart.Count
    //            };
    //            _unitOfWork.OrderItem.Add(orderItem);
				//_unitOfWork.Save();
    //        }

            return RedirectToAction("Index");
        }
        public IActionResult Minus(int shoppingCartId)
        {
			var shoppingCart = _unitOfWork.ShoppingCart.Get(u => u.Id == shoppingCartId);
            if (shoppingCart.Count <= 1)
            {
                _unitOfWork.ShoppingCart.Remove(shoppingCart);
            }
            else
            {
                shoppingCart.Count -= 1;
                _unitOfWork.ShoppingCart.Update(shoppingCart);
            }
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int shoppingCartId)
        {
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			var shoppingCart = _unitOfWork.ShoppingCart.Get(u => u.Id == shoppingCartId);
            _unitOfWork.ShoppingCart.Remove(shoppingCart);
			_unitOfWork.Save();

			HttpContext.Session.SetInt32("SessionShoppingCart",
            _unitOfWork.ShoppingCart.GetAll(u => u.CustomerId == userId).Count());
            return RedirectToAction("Index");
        }
    }
}
