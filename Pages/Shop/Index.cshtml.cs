using MagicShopLibrary;
using MagicShopLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            Shop = new MagicShop(new MagicShopOptions(
                Request.Form["levelFilter"],
                Request.Form["typeFilter"],
                Request.Form["sizeFilter"]));
        }
        public enum PlayerLevel
        {
            One = 1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Eleven,
            Twelve,
            Thirteen,
            Fourteen,
            Fifteen,
            Sixteen,
            Seventeen,
            Eighteen,
            Nineteen,
            Twenty
        }
        private int FormToLevel(string level)
        {
            switch (level)
            {
                case "One":
                    return 1;
                case "Two":
                    return 2;
                case "Three":
                    return 3;
                default:
                    break;
            }
        }
        private ShopType FormToType(string type)
        {

        }
        private ShopSize FormToSize(string size)
        {

        }
    }
}
