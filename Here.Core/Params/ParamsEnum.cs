namespace Here.Params
{
    public class ParamsEnum<T> : ParamsBase<T>
    {
        public ParamsEnum(string nom, T valeur) : base(nom, valeur)
        {
        }

        public override string ValeurStr => string.Format("{0}", Valeur.ToString().ToLower());

    }
}
