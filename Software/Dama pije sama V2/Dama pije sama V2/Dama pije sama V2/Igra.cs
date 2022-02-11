using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dama_pije_sama_V2
{
    [Table("Igra2")]
    public class Igra
    {
        [PrimaryKey, AutoIncrement, NotNull]
        [Preserve]
        public int Id { get; set; }
        [NotNull]
        public DateTime Datum { get; set; }
  
        public string PopisIgraca { get; set; }
        [NotNull]
        public int BrOdigranihKarata { get; set; }
        [NotNull]
        public string DuljinaIgre { get; set; }
        public int BrojIgraca { get; set; }

        public Igra()
        {

        }
    }
}
