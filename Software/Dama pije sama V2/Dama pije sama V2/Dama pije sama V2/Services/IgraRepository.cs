using Dama_pije_sama_V2;
using DamaPijeSama.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(IgraRepository))]
namespace Dama_pije_sama_V2
{
    public class IgraRepository : IIgraRepository
    {
        SQLiteAsyncConnection conn;
        async Task Init()
        {
            if (conn != null)
            {
                return;
            }
            var dbPath = FileAccessHelper.GetLocalFilePath("damapijesama.db3");
            conn = new SQLiteAsyncConnection(dbPath);
            await conn.CreateTableAsync<Igra>();
        }

        public async Task AddNewIgraAsync(Igra novaIgra)
        {
            await Init();
            try
            {
                await conn.InsertAsync(novaIgra);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Something went wrong there :(Try again or contact support. Here's the full error: {ex}", "OK");
            }
        }
        public async Task<List<Igra>> GetIgreAsync()
        {
            await Init();
            try
            {
                return await conn.Table<Igra>().ToListAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Something went wrong there :(Try again or contact support. Here's the full error: {ex}", "OK");
            }
            return new List<Igra>();
        }
    }
}
