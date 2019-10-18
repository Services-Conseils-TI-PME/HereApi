using System;

namespace Here.Models
{
    public class CalculDistanceRetourModel
    {
        public int Distance { get; set; }
        public TimeSpan Delais { get; set; }

        public void SetDelais(int Delaissecondes)
        {
            Delais = TimeSpan.FromSeconds(Delaissecondes);
        }

        public string DelaisStr()
        {
            return string.Format("{0:D2}h{1:D2}",
                            Delais.Hours,
                            Delais.Minutes);
        }

        public string Notes { get; set; }
    }
}