using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DnDCharacterCreator.Models;
using System.Text;
using System;
using DnDCharacterCreator.Options;
using DnDCharacterCreator.Classes;
using DnDCharacterCreator.Races;
using DnDCharacterCreator.Interfaces;

namespace WumbosDnDToolbox.Pages.NPCs
{
    public class IndexModel : PageModel
    {
        public Character character;
        public IRace Race;
        public IClass Class;
        
        public void OnGet()
        {
            character = new Character();
            Race = new Dragonborn();
            Class = new Barbarian();
        }

        public ActionResult OnPostGenerate()
        {
            Race = FormToRace(Request.Form["raceSelect"]);
            Class = FormToClass(Request.Form["classSelect"]);
            character = new Character(
                FormToClass(Request.Form["classSelect"]),
                FormToRace(Request.Form["raceSelect"])
                );
            return Page();
        }

        private IClass FormToClass(string _class)
        {
            switch (_class)
            {
                case "":
                    return null;
                case "Barbarian":
                    return new Barbarian();
                case "Bard":
                    return new Bard();
                case "Cleric":
                    return new Cleric();
                case "Druid":
                    return new Druid();
                case "Fighter":
                    return new Fighter();
                case "Monk":
                    return new Monk();
                case "Paladin":
                    return new Paladin();
                case "Ranger":
                    return new Ranger();
                case "Rouge":
                    return new Rouge();
                case "Sorcerer":
                    return new Sorcerer();
                case "Warlock":
                    return new Warlock();
                case "Wizard":
                    return new Wizard();
                default:
                    return null;
            }
        }

        private IRace FormToRace(string race)
        {
            switch (race)
            {
                case "":
                    return null;
                case "Dragonborn":
                    return new Dragonborn();
                case "Dwarf":
                    return new Dwarf();
                case "Elf":
                    return new Elf();
                case "Gnome":
                    return new Gnome();
                case "HalfElf":
                    return new HalfElf();
                case "Halfling":
                    return new Halfling();
                case "HalfOrc":
                    return new HalfOrc();
                case "Human":
                    return new Human();
                case "Tiefling":
                    return new Tiefling();
                default:
                    return null;
            }
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
