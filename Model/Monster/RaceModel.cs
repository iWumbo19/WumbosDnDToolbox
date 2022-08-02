namespace WumbosDnDToolbox.Model.Monster
{
    public class RaceModel
    {
        public string index;
        public string name;
        public int speed;
        public AbilityBonusModel[] ability_bonuses;
        public string alignment;
        public string size;
        public string size_description;
        public APIReferenceModel[] starting_proficiencies;
        public ChoiceModel starting_proficiency_options;
        public APIReferenceModel[] languages;
        public string language_desc;
        public APIReferenceModel[] traits;
        public APIReferenceModel[] subraces;
        public string url;
    }
}
