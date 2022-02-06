using System;
using System.Collections.Generic;
using System.Text;

namespace Dama_pije_sama_V2
{
    public class Igrac
    {
        public string Ime { get; set; }
        public int RedniBroj { get; set; }
        public Igrac (string ime, int redniBroj)
        {
            Ime = ime;
            RedniBroj = redniBroj;
        }

        public override string ToString()
        {
            return Ime;
        }
    }
}
