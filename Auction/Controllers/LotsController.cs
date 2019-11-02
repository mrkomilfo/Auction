using Auction.Data.DB;
using Auction.ViewModels;
using Auction.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using static Auction.Data.Dict;

namespace Auction.Controllers
{   
    public class LotsController : Controller
    {
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
        public ActionResult LotDetail(int? id)
        {
            if (id != null)
            {
                Lot lot = db.Lots.Include(l => l.User).Include(l => l.Bids).ThenInclude(b => b.User).FirstOrDefault(l => l.Id == id);
                if (lot != null)
                {
                    LotDetailViewModel obj = new LotDetailViewModel
                    {
                        Lot = lot,
                        BidPrice = lot.Price + 100,
                        BidId = (int)id
                    };
                    return View(obj);
                }
            }
            return NotFound();
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]     
        public async Task<IActionResult> Create(CreateLotViewModel model)
        {
            if (ModelState.IsValid)
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
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> MakeBid(LotDetailViewModel model)
        {
            Lot lot = db.Lots.Include(l => l.User).Include(l => l.Bids).FirstOrDefault(l => l.Id == model.BidId);
            if (ModelState.IsValid && lot.IsActual())
            {
                User user = await _userManager.GetUserAsync(HttpContext.User);
                
                Bid bid = new Bid
                {                   
                    User = user,
                    NewPrice = model.BidPrice,
                    Lot = lot,
                    Time = DateTime.Now
                };
                db.Bids.Add(bid);
                lot.Price = model.BidPrice;
                db.Lots.Update(lot);          
                db.SaveChanges();
                return RedirectToAction("LotDetail", new {id = lot.Id});
            }
            return RedirectToAction("LotDetail", new { id = lot.Id });
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckBid(uint BidPrice, int BidId)
        {
            if (BidPrice <= db.Lots.First(l=>l.Id == BidId).Price)
                return Json(false);
            return Json(true);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Lot lot = await db.Lots.FirstOrDefaultAsync(l => l.Id == id);
                if (lot != null)
                {
                    string path = "wwwroot/img/" + id + ".jpg";
                    System.IO.File.Delete(path);
                    db.Bids.RemoveRange(db.Bids.Where(b => b.Lot.Id == id));                    
                    db.Lots.Remove(lot);
                    await db.SaveChangesAsync();
                    return RedirectToAction("ActualLots");
                }
            }
            return NotFound();
        }
    }
}
