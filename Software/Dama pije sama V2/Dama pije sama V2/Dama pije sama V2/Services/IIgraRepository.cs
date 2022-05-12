using Dama_pije_sama_V2;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DamaPijeSama.Services
{
    public interface IIgraRepository
    {
        Task AddNewGameAsync(Game newGame);
        Task<List<Game>> GetGamesAsync();
        Task DeleteAllGamesAsync();
    }
}
