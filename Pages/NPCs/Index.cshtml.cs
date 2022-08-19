using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DnDCharacterCreator.Models;
using System.Text;
using System;
using DnDCharacterCreator.Options;

namespace WumbosDnDToolbox.Pages.NPCs
{
    public class IndexModel : PageModel
    {
        public Character character;
        public void OnGet()
        {
            character = new Character();
        }

        public string GetProficiencies()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Languages");
            foreach (StandardLanguage language in Enum.GetValues(typeof(StandardLanguage)))
            {
                if (character.IsProficient(language)) sb.Append($"{language}, ");
            }
            foreach (ExoticLanguage language in Enum.GetValues(typeof(ExoticLanguage)))
            {
                if (character.IsProficient(language)) sb.Append($"{language}, ");
            }
            sb.AppendLine(" ");
            sb.AppendLine(" ");

            sb.AppendLine("Tools");
            foreach (ArtisanTool tool in Enum.GetValues(typeof(ArtisanTool)))
            {
                if (character.IsProficient(tool)) sb.Append($"{tool}, ");
            }

            return sb.ToString();
        }
    }
}
