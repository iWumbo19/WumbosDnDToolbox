using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
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

        [BindProperty(SupportsGet = true)]
        public string? TypeFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CRFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool FilterIsAnd { get; set; }

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
            monsters = MonsterDb._monsters;
            if (!FilterIsAnd) // AND FILTER
            {
                if (!string.IsNullOrEmpty(NameFilter))
                {
                    var filtered = monsters.Where(s => s.name.Contains(NameFilter, System.StringComparison.OrdinalIgnoreCase)).ToArray();
                    monsters = filtered;
                }
                if (!string.IsNullOrEmpty(SizeFilter))
                {
                    var filtered = monsters.Where(s => s.size.Contains(SizeFilter, System.StringComparison.OrdinalIgnoreCase)).ToArray();
                    monsters = filtered;
                }
                if (!string.IsNullOrEmpty(TypeFilter))
                {
                    var filtered = monsters.Where(s => s.type.Contains(TypeFilter, System.StringComparison.OrdinalIgnoreCase)).ToArray();
                    monsters = filtered;
                }
            }
            else // OR FILTER
            {
                HashSet<MonsterModel> results = new HashSet<MonsterModel>();
                if (NameFilter != null)
                    results.UnionWith(MonsterDb._monsters.Where(s =>
                        s.name.Contains(NameFilter, System.StringComparison.OrdinalIgnoreCase))
                        .ToArray());
                if (string.IsNullOrEmpty(Request.Form["sizeFilter"].ToString())) 
                    results.UnionWith(MonsterDb._monsters.Where(s => 
                        s.size.Contains(Request.Form["sizeFilter"], System.StringComparison.OrdinalIgnoreCase))
                        .ToArray());
                if (string.IsNullOrEmpty(Request.Form["typeFilter"].ToString())) 
                    results.UnionWith(MonsterDb._monsters.Where(s => 
                        s.type.Contains(Request.Form["typeFilter"], System.StringComparison.OrdinalIgnoreCase))
                        .ToArray());

                monsters = results.ToArray();
            }
            RedirectToPage("Index");
        }


        public void OnPostClear()
        {
            NameFilter = null;
            SizeFilter = null;
            TypeFilter = null;
            ModelState.Clear();
            RedirectToPage("Index");
        }
    }
}
