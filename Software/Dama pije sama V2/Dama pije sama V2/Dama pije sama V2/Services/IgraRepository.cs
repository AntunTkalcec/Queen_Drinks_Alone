using Dama_pije_sama_V2;
using DamaPijeSama.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Helpers;
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
            await conn.CreateTableAsync<Game>();
        }

        public async Task AddNewGameAsync(Game newGame)
        {
            await Init();
            try
            {
                if (!await CheckGameExists(newGame))
                {
                    await conn.InsertAsync(newGame);
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", LocalizationResourceManager.Current["GeneralDBError"], "OK");
            }
        }
        public async Task<List<Game>> GetGamesAsync()
        {
            await Init();
            try
            {
                return await conn.Table<Game>().ToListAsync();
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", LocalizationResourceManager.Current["GeneralDBError"], "OK");
            }
            return new List<Game>();
        }
        public async Task<bool> CheckGameExists(Game game)
        {
            await Init();
            try
            {
                if (await conn.FindAsync<Game>(game.Id) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", LocalizationResourceManager.Current["GeneralDBError"], "OK");
            }
            return false;
        }

        public async Task DeleteAllGamesAsync()
        {
            await Init();
            try
            {
                await conn.DeleteAllAsync<Game>();
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", LocalizationResourceManager.Current["GeneralDBError"], "OK");
            }
        }
    }
}
