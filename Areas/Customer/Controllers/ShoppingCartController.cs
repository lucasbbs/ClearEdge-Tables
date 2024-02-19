using group_web_application_security.Models;
using group_web_application_security.Models.ViewModels;
using group_web_application_security.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace group_web_application_security.Areas.Customer.Controllers
{
    [Area("customer")]
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

			if (ModelState.IsValid)
            {
                ShoppingCartViewModel.Order.Status = "Pending";
                ShoppingCartViewModel.Order.PaymentStatus = "Pending";

                _unitOfWork.Order.Add(ShoppingCartViewModel.Order);
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

            foreach (var cart in ShoppingCartViewModel.ShoppingCartList)
            {
                OrderItem orderItem = new()
                {
                    TableId = cart.TableId,
                    OrderId = ShoppingCartViewModel.Order.Id,
                    Price = cart.Price,
                    Count = cart.Count
                };
                _unitOfWork.OrderItem.Add(orderItem);
                _unitOfWork.Save();
            }

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
            var shoppingCart = _unitOfWork.ShoppingCart.Get(u => u.Id == shoppingCartId);
            _unitOfWork.ShoppingCart.Remove(shoppingCart);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
