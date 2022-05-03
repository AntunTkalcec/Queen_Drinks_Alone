using Dama_pije_sama_V2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DamaPijeSama.Services
{
    public interface IIgraRepository
    {
        Task AddNewIgraAsync(Igra novaIgra);
        Task<List<Igra>> GetIgreAsync();
    }
}
