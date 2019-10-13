using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Data.Interfaces;
using Auction.Data.Models;
using Auction.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    public class LotController : Controller
    {
        private readonly Lot _lot;
        private readonly ILots allLots;

        public LotController(Lot lot)
        {
            _lot = lot;
        }

        [HttpGet]
        //[Route("Lots/LotsList/")]
        public ViewResult LotDetail(int id)
        {
            LotDetailViewModel obj = new LotDetailViewModel {
                lot = allLots.getLot(id)
            };
            return View(obj);
        }


    }
}