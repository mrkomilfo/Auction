using Auction.Data.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using System;

namespace Auction.TagHelpers
{
    public class ObjLinkTagHelper : TagHelper
    {
        public object Obj { get; set;  }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            Type type = Obj.GetType();
            if (type == typeof(Lot))
            {
                Lot lot = (Lot)Obj;
                output.Attributes.SetAttribute("href", "/Lots/LotDetail?id=" + lot.Id);
                if ((await output.GetChildContentAsync()).GetContent().Length == 0)
                {
                    output.Content.SetContent(lot.Name);
                }
            }
            else if (type == typeof(User))
            { 
                User user = (User)Obj;
                output.Attributes.SetAttribute("href", "/Users/Profile?id=" + user.Id);
                if ((await output.GetChildContentAsync()).GetContent().Length == 0)
                {
                    output.Content.SetContent(user.UserName);
                }
            }            
        }
    }
}
