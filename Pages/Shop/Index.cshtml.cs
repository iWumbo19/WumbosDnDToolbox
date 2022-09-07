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
    }
}
