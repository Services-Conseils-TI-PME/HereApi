namespace Here.Models
{
    public class RouteDistanceModel
    {
        public AdresseModel Depart { get; set; }
        public AdresseModel Destination { get; set; }

        public int Poids { get; set; }
        public int Longueur { get; set; }
        public int Largeur { get; set; }

        public RouteDistanceModel()
        {
            Depart = new AdresseModel() { NoCivique = 337, Rue = "Morreault", Ville = "Rimouski", Pays = "CAN" };
            Destination = new AdresseModel() { NoCivique = 150, Rue = "René-Lévesque", Ville = "Québec", Pays = "CAN" };
            Poids = 50000;
            Longueur = 14;
            Largeur = 2;
        }
    }
}