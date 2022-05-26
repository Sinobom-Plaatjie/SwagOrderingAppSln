using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwagOrderingApp
{
    public class SwagItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<SwagItemDatabase> Instance = new AsyncLazy<SwagItemDatabase>(async () =>
        {
            var instance = new SwagItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<SwagItem>();
            return instance;
        });

        public SwagItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<SwagItem>> GetItemsAsync()
        {
            return Database.Table<SwagItem>().ToListAsync();
        }

        public Task<List<SwagItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<SwagItem>("SELECT * FROM [SwagItem] WHERE [Done] = 0");
        }

        public Task<SwagItem> GetItemAsync(int id)
        {
            return Database.Table<SwagItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(SwagItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(SwagItem item)
        {
            return Database.DeleteAsync(item);
        }
    }

}
