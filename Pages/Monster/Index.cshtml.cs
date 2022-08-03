using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using WumbosDnDToolbox.Data;
using WumbosDnDToolbox.Model;

namespace WumbosDnDToolbox.Pages.Monster
{
    public class DatabaseModel : PageModel
    {
        public MonsterModel[] monsters = MonsterDb._monsters;

        [BindProperty(SupportsGet = true)]
        public string? NameFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SizeFilter { get; set; }

        public void OnGet()
        {
            monsters = MonsterDb._monsters;
        }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(NameFilter))
            {
                var filtered = MonsterDb._monsters.Where(s => s.name.Contains(NameFilter)).ToArray();
                monsters = filtered;
            }
            RedirectToPage("Index");
        }

        public void OnPostSearch()
        {
            if (!string.IsNullOrEmpty(NameFilter))
            {
                var filtered = MonsterDb._monsters.Where(s => s.name.Contains(NameFilter)).ToArray();
                monsters = filtered;
            }
            if (!string.IsNullOrEmpty(SizeFilter))
            {
                var filtered = monsters.Where(s => s.size.Contains(SizeFilter)).ToArray();
                monsters = filtered;
            }
            RedirectToPage("Index");
        }


        public void OnPostClear()
        {
            NameFilter = null;
            SizeFilter = null;
            ModelState.Clear();
            RedirectToPage("Index");
        }
    }
}
