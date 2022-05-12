using SQLite;
using System;

namespace Dama_pije_sama_V2
{
    [Table("Games")]
    public class Game
    {
        [PrimaryKey, AutoIncrement, NotNull]
        [Preserve]
        public int Id { get; set; }
        [NotNull]
        public DateTime Date { get; set; }
  
        public string PlayerList { get; set; }
        [NotNull]
        public int CardsPlayed { get; set; }
        [NotNull]
        public string GameLength { get; set; }
        public int NumberOfPlayers { get; set; }

        public Game()
        {

        }
    }
}
