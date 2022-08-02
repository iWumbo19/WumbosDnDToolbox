using WumbosDnDToolbox.Model.Monster;

namespace WumbosDnDToolbox.Model
{
    public class MonsterModel
    {
        public string index;
        public string name;
        public string size;
        public string type;
        public string subtype;
        public string alignment;
        public int armor_class;
        public int hit_points;
        public string hit_dice;
        public APIReferenceModel[] forms;
        public SpeedModel speed;
        public int strength;
        public int dexterity;
        public int constitution;
        public int intelligence;
        public int wisdom;
        public int charisma;
        public ProficiencyModel[] proficiencies;
        public string[] damage_vulnerabilities;
        public string[] damage_resistances;
        public string[] damage_immunities;
        public APIReferenceModel[] condition_immunities;
        public SensesModel senses;
        public string languages;
        public double challenge_rating;
        public SpecialAbilityModel[] special_abilities;
        public ActionModel[] actions;
        public ActionModel[] legendary_actions;
        public string url;
        public int xp;
    }
}
