namespace Dama_pije_sama_V2
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Player(int id, string name, string image)
        {
            Id = id;
            Name = name;
            Image = image;  
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
