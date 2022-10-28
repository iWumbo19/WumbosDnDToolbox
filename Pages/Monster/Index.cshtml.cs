using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using WumbosDnDToolbox.Data;
using WumbosDnDToolbox.Model;
using DnD5e.MonsterDatabase;
using DnD5e.MonsterDatabase.Models;

namespace WumbosDnDToolbox.Pages.Monster
{
    public class DatabaseModel : PageModel
    {
        public MonsterModelList Monsters;


        public void OnGet()
        {
            Monsters = DnD5e.MonsterDatabase.Data.GetAllMonsters();
        }

        public void OnPostFilter()
        {

        }
    }
}
