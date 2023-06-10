using MauiTestApp.Models;
using SQLite;

namespace MauiTestApp.Data
{
    public class TestDatabase
    {
        SQLiteAsyncConnection Database;

        public TestDatabase()
        {
        }

        //Init method delays initialisation of database class until called
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.EnableWriteAheadLoggingAsync();
            var result = await Database.CreateTableAsync<NoteItem>();
        }

        //Data manipulation methods, each call Init method before carrying out operation
        public async Task<List<NoteItem>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<NoteItem>().ToListAsync();
        }

        public async Task<NoteItem> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<NoteItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(NoteItem item)
        {
            await Init();
            if (item.Id != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(NoteItem item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
