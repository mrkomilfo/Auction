using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Auction.Data.Models;
using Auction.Data.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Auction.Controllers
{
    public class UsersController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<User> _userManager;
        ApplicationContext db;

        public UsersController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, ApplicationContext contex)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            db = contex;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index() => View(_userManager.Users.ToList());

        [Authorize(Roles = "admin")]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.UserName, Registration = DateTime.Now };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user");
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Roles(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.ToList();
            EditRolesViewModel model = new EditRolesViewModel
            {
                Id = user.Id,
                /*Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,*/
                UserRoles = userRoles,
                AllRoles = allRoles
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Roles(EditRolesViewModel model, List<string> roles)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    /*user.Email = model.Email;
                    user.UserName = model.UserName;
                    user.PhoneNumber = model.PhoneNumber;*/

                    var userRoles = await _userManager.GetRolesAsync(user);
                    var allRoles = _roleManager.Roles.ToList();
                    var addedRoles = roles.Except(userRoles);
                    var removedRoles = userRoles.Except(roles);
                    await _userManager.AddToRolesAsync(user, addedRoles);
                    await _userManager.RemoveFromRolesAsync(user, removedRoles);

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        await _userManager.UpdateSecurityStampAsync(user);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(string id)
        {
            User user = await db.Users.Include(u => u.Lots).FirstAsync(u => u.Id == id);
            if (user != null)
            {
                db.Bids.RemoveRange(db.Bids.Where(b => b.User.Id == id || b.Lot.User.Id == id));
                foreach (Lot lot in user.Lots)
                {
                    string path = "wwwroot/img/" + lot.Id + ".jpg";
                    System.IO.File.Delete(path);
                }
                db.Lots.RemoveRange(db.Lots.Where(l => l.User.Id == id));
                db.Users.Remove(user);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Profile(string id)
        {
            User user = db.Users.Include(u => u.Lots).Include(u => u.Bids).ThenInclude(u => u.Lot).FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            User currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(user);
            ProfileViewModel obj = new ProfileViewModel
            {
                User = user,
                IsMy = (currentUser != null && currentUser.Id == id) ? true : false
            };
            return View(obj);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckEmail(string email, string id)
        {
            if (db.Users.Any(u => u.Email == email && u.Id != id))
                return Json(false);
            return Json(true);
        }
    }
}
