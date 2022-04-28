using Xamarin.Forms;

namespace Dama_pije_sama_V2
{
    public class Igrac
    {
        public string Ime { get; set; }
        public Frame Frame { get; set; }
        public Igrac (string ime, Frame frame)
        {
            Ime = ime;
            Frame = frame;
        }

        public override string ToString()
        {
            return Ime;
        }
    }
}
