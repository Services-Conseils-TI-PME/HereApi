namespace HereTruckDistance.Core
{
    public interface IParamBase
    {
        string Nom { get; }
        string ValeurStr { get; }

        string ToString();
    }
}