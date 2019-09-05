using Auction.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Interfaces
{
    public interface ICategories
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
