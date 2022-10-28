using DnD5e.MonsterDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace WumbosDnDToolbox.Pages.Monster
{
    public class DetailsModel : PageModel
    {
        public MonsterModel _monster;
        public void OnGet(string name)
        {
            if (name == null) throw new Exception();
            _monster = DnD5e.MonsterDatabase.Data.GetMonster(name);
        }

        public string Modifier(int score)
        {
            switch (score)
            {
                case 1: return "-5";
                case int n when (n == 2 | n == 3): return "-4";
                case int n when (n == 4 | n == 5): return "-3";
                case int n when (n == 6 | n == 7): return "-2";
                case int n when (n == 8 | n == 9): return "-1";
                case int n when (n == 10 | n == 11): return "+0";
                case int n when (n == 12 | n == 13): return "+1";
                case int n when (n == 14 | n == 15): return "+2";
                case int n when (n == 16 | n == 17): return "+3";
                case int n when (n == 18 | n == 19): return "+4";
                case int n when (n == 20 | n == 21): return "+5";
                case int n when (n == 22 | n == 23): return "+6";
                case int n when (n == 24 | n == 25): return "+7";
                case int n when (n == 26 | n == 27): return "+8";
                case int n when (n == 28 | n == 29): return "+9";
                case 30: return "+10";
                default: return "-";
            }
        }
    }
}
