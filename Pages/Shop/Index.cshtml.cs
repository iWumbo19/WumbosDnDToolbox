using MagicShopLibrary;
using MagicShopLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace WumbosDnDToolbox.Pages.Shop
{
    public class IndexModel : PageModel
    {
        public MagicShop Shop { get; set; }
        public void OnGet()
        {
            Shop = new MagicShop(20);
        }

        public void OnPostSearch()
        {
            Shop = new MagicShop(
                new MagicShopOptions(
                    (int)Utilities.StringToPlayerLevel[Request.Form["levelFilter"]],
                    Utilities.StringToShopType[Request.Form["typeFilter"]],
                    Utilities.StringToShopSize[Request.Form["sizeFilter"]])
                );
        }
    }
}
