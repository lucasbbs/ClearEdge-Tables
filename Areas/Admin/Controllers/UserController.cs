using ClearEdge_Tables.Models.ViewModels;
using ClearEdge_Tables.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ClearEdge_Tables.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RoleManagment(string userId)
        {

            RoleManagementViewModel RoleViewManager = new RoleManagementViewModel()
            {
                Customer = _unitOfWork.Customer.Get(u => u.Id == userId),
                RoleList = _roleManager.Roles.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Name
                })
            };

            RoleViewManager.Customer.Role = _userManager.GetRolesAsync(_unitOfWork.Customer.Get(u => u.Id == userId))
                    .GetAwaiter().GetResult().FirstOrDefault();
            return View(RoleViewManager);
        }

        [HttpPost]
        public IActionResult RoleManagment(RoleManagementViewModel roleManagmentVM)
        {

            string oldRole = _userManager.GetRolesAsync(_unitOfWork.Customer.Get(u => u.Id == roleManagmentVM.Customer.Id))
                    .GetAwaiter().GetResult().FirstOrDefault();

            ClearEdge_Tables.Models.Customer applicationUser = _unitOfWork.Customer.Get(u => u.Id == roleManagmentVM.Customer.Id);


            if (!(roleManagmentVM.Customer.Role == oldRole))
            {
                _unitOfWork.Customer.Update(applicationUser);
                _unitOfWork.Save();

                _userManager.RemoveFromRoleAsync(applicationUser, oldRole).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(applicationUser, roleManagmentVM.Customer.Role).GetAwaiter().GetResult();

            }

            return RedirectToAction("Index");
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ClearEdge_Tables.Models.Customer> objUserList = _unitOfWork.Customer.GetAll().ToList();

            foreach (var user in objUserList)
            {

                user.Role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();

                //if (user.Company == null)
                //{
                //    user.Company = new Company()
                //    {
                //        Name = ""
                //    };
                //}
            }

            return Json(new { data = objUserList });
        }


        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {

            var objFromDb = _unitOfWork.Customer.Get(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking" });
            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //user is currently locked and we need to unlock them
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _unitOfWork.Customer.Update(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Operation Successful" });
        }

        #endregion
    }
}