using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dama_pije_sama_V2
{
    public class IgraRepository
    {
        SQLiteAsyncConnection conn;
        public string StatusMessage { get; set; }
        public IgraRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Igra>().Wait();
        }

        public async Task AddNewIgraAsync(Igra novaIgra)
        {
            int result = 0;

            try
            {
                result = await conn.InsertAsync(novaIgra);
                StatusMessage = string.Format("{0} item(s) added [Name: {1})", result, novaIgra.Id);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Something went wrong there :(Try again or contact support. Here's the full error: {ex}", "OK");
            }
        }
        public async Task<List<Igra>> GetIgreAsync()
        {
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
