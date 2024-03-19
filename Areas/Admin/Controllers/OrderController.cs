using ClearEdge_Tables.Models;
using ClearEdge_Tables.Models.ViewModels;
using ClearEdge_Tables.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Climate;
using System.Security.Claims;

namespace ClearEdge_Tables.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public OrderViewModel orderVM { get; set; }
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int orderId)
        {
            orderVM = new()
            {
                Order = _unitOfWork.Order.Get(u => u.Id == orderId, includeProperties: "Customer"),
                OrderItem = _unitOfWork.OrderItem.GetAll(u => u.OrderId == orderId, includeProperties: "Table")
            };

            return View(orderVM);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateOrderDetail()
        {
            var orderFromDb = _unitOfWork.Order.Get(u => u.Id == orderVM.Order.Id);
            orderFromDb.Name = orderVM.Order.Name;
            orderFromDb.PhoneNumber = orderVM.Order.PhoneNumber;
            orderFromDb.StreetAddress = orderVM.Order.StreetAddress;
            orderFromDb.City = orderVM.Order.City;
            orderFromDb.State = orderVM.Order.State;
            orderFromDb.PostalCode = orderVM.Order.PostalCode;
            if (!string.IsNullOrEmpty(orderVM.Order.Carrier))
            {
                orderFromDb.Carrier = orderVM.Order.Carrier;
            }
            if (!string.IsNullOrEmpty(orderVM.Order.TrackingNumber))
            {
                orderFromDb.Carrier = orderVM.Order.TrackingNumber;

            }
            _unitOfWork.Order.Update(orderFromDb);
            _unitOfWork.Save();

            TempData["Success"] = "Order Details Updated Successfully.";


            return RedirectToAction(nameof(Details), new { orderId = orderFromDb.Id });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult StartProcessing()
        {
            _unitOfWork.Order.UpdateStatus(orderVM.Order.Id, "Processing");
            _unitOfWork.Save();
            TempData["Success"] = "Order Details Updated Successfully.";
            return RedirectToAction(nameof(Details), new { orderId = orderVM.Order.Id });
        }

        [HttpPost]
        [Authorize(Roles =  "Admin")]
        public IActionResult ShipOrder()
        {

            var orderHeader = _unitOfWork.Order.Get(u => u.Id == orderVM.Order.Id);
            orderHeader.TrackingNumber = orderVM.Order.TrackingNumber;
            orderHeader.Carrier = orderVM.Order.Carrier;
            orderHeader.Status = "Shipped";
            orderHeader.Shipping_Date = DateTime.Now;

            _unitOfWork.Order.Update(orderHeader);
            _unitOfWork.Save();
            TempData["Success"] = "Order Shipped Successfully.";
            return RedirectToAction(nameof(Details), new { orderId = orderVM.Order.Id });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CancelOrder()
        {

            var orderHeader = _unitOfWork.Order.Get(u => u.Id == orderVM.Order.Id);

            if (orderHeader.PaymentStatus == "Approved")
            {
                var options = new RefundCreateOptions
                {
                    Reason = RefundReasons.RequestedByCustomer,
                    PaymentIntent = orderHeader.PaymentIntentId
                };

                var service = new RefundService();
                Refund refund = service.Create(options);

                _unitOfWork.Order.UpdateStatus(orderHeader.Id, "Cancelled", "Refunded");
            }
            else
            {
                _unitOfWork.Order.UpdateStatus(orderHeader.Id, "Cancelled", "Cancelled");
            }
            _unitOfWork.Save();
            TempData["Success"] = "Order Cancelled Successfully.";
            return RedirectToAction(nameof(Details), new { orderId = orderVM.Order.Id });

        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll(string status)
        {
            IEnumerable<ClearEdge_Tables.Models.Order> orders;

            if (User.IsInRole("Admin"))
            {
                orders = _unitOfWork.Order.GetAll(includeProperties: "Customer").ToList();
            }
            else
            {

                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                orders = _unitOfWork.Order
                    .GetAll(u => u.customerId == userId, includeProperties: "Customer");
            }


            switch (status)
            {
                case "pending":
                    orders = orders.Where(u => u.Status == "Pending");
                    break;
                case "inprocess":
                    orders = orders.Where(u => u.Status == "Processing");
                    break;
                case "completed":
                    orders = orders.Where(u => u.Status == "Shipped");
                    break;
                case "approved":
                    orders = orders.Where(u => u.Status == "Approved");
                    break;
                default:
                    break;

            }


            return Json(new { data = orders });
        }


        #endregion

    }
}
