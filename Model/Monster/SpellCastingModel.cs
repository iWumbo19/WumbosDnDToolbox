namespace WumbosDnDToolbox.Model.Monster
{
    public class SpellCastingModel
    {
        public int level;
        public APIReferenceModel spellcasting_ability;
        public SpellCastingRef[] info;
    }

    public class SpellCastingRef
    {
        public string[] desc;
        public string name;
    }
}
