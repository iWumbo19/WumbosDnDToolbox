namespace WumbosDnDToolbox.Model.Monster
{
    public class ClassModel
    {
        public string index;
        public string name;
        public int hit_die;
        public ChoiceModel[] proficiency_choices;
        public APIReferenceModel[] proficiencies;
        public APIReferenceModel[] saving_throws;
        public object starting_equipment;
        public string class_levels;
        public object multi_classing;
        public APIReferenceModel[] subclasses;
        public SpellCastingModel spellcasting;
        public string spells;
        public string url;
    }
}
