namespace Dama_pije_sama_V2
{
    public class Karta
    {
        public string Naziv { get; set; }
        public string Naredba { get; set; }

        public Karta(string naziv, string naredba)
        {
            Naziv = naziv;
            Naredba = naredba;
        }
    }
}
