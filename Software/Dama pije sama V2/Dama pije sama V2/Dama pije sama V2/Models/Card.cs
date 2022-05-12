namespace Dama_pije_sama_V2
{
    public class Card
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Card(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
