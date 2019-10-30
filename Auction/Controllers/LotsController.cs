using Auction.Data.DB;
using Auction.Data.Interfaces;
using Auction.ViewModels;
using Auction.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Auction.Data.Dict;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace Auction.Controllers
{   
    public class LotsController : Controller
    {
        //private readonly ILots allLots;
        private ApplicationContext db;
        private UserManager<User> _userManager;
        private IHostingEnvironment _appEnvironment;

        public LotsController(ApplicationContext context, UserManager<User> userManager, IHostingEnvironment appEnvironment)
        {
            db = context;
            _userManager = userManager;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public ViewResult ActualLots()
        {
            LotsListViewModel obj = new LotsListViewModel();
            //obj.allLots = allLots.ActualLots;
            obj.AllLots = db.Lots.Include(l => l.User).Where(l => l.IsActual()).OrderByDescending(l => l);     
            return View("LotsList", obj);
        }

        [HttpGet]
        public ViewResult EndedLots()
        {
            LotsListViewModel obj = new LotsListViewModel();
            //obj.allLots = allLots.EndedLots;
            obj.AllLots = db.Lots.Include(l => l.User).Where(l => !l.IsActual()).OrderByDescending(l => l);
            return View("LotsList", obj);
        }

        [HttpGet]
        public ViewResult LotDetail(int id)
        {
            LotDetailViewModel obj = new LotDetailViewModel
            {
                Lot = db.Lots.Include(l => l.User).Include(l => l.Bids).FirstOrDefault(l => l.Id == id)
            };
            return View(obj);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]     
        public async Task<IActionResult> Create(CreateLotViewModel model)
        {           
            Lot lot = new Lot
            {
                Name = model.Name,
                Year = model.Year,
                EngineVolume = double.Parse(model.EngineVolume),
                Milleage = model.Mileage,
                Price = model.Price,
                Transmission = (ushort)Array.IndexOf(transmission, model.Transmission),               
                Fuel = (ushort)Array.IndexOf(fuel, model.Fuel),
                Body = (ushort)Array.IndexOf(body, model.Body),
                Drive = (ushort)Array.IndexOf(drive, model.Drive),
                Desc = model.Desc,
                Exposing = DateTime.Now,
                Ending = DateTime.Now.AddDays(model.Duration),
                User = await _userManager.GetUserAsync(HttpContext.User)
            };
            db.Lots.Add(lot);           
            db.SaveChanges();
            if (model.Image != null)
            {
                // путь к папке Files
                string path = "/img/" + lot.Id + ".jpg";
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }
                lot.Image = path;
            }
            db.Lots.Update(lot);
            db.SaveChanges();
            return RedirectToAction("ActualLots");
        }
    }
}
