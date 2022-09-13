using MagicShopLibrary;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WumbosDnDToolbox.Pages.Shop
{
    public class IndexModel : PageModel
    {
        public MagicShop Shop { get; set; }
        public void OnGet()
        {
            Shop = new MagicShop(5);
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
