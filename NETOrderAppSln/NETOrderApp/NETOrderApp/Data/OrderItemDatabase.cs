using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using OrderItems.Models;
using NETOrderApp;

namespace OrderItems.Data
{
    public class OrderItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<OrderItemDatabase> Instance = new AsyncLazy<OrderItemDatabase>(async () =>
        {
            var instance = new OrderItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<OrderItem>();
            return instance;
        });

        public OrderItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<OrderItem>> GetItemsAsync()
        {
            return Database.Table<OrderItem>().ToListAsync();
        }

        public Task<List<OrderItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<OrderItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<OrderItem> GetItemAsync(int id)
        {
            return Database.Table<OrderItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(OrderItem item)
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

        public Task<int> DeleteItemAsync(OrderItem item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
