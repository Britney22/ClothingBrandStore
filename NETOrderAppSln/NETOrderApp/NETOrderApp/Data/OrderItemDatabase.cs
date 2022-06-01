using System.Collections.Generic;
using System.Threading.Tasks;
using OrderItems.Models;

namespace NETOrderApp.Data
{
    public class OrderItemDatabase
    {
       
        
        
            static SQLiteAsyncConnection Database;

            public static readonly AsyncLazy<TodoItemDatabase> Instance = new AsyncLazy<TodoItemDatabase>(async () =>
            {
                var instance = new TodoItemDatabase();
                CreateTableResult result = await Database.CreateTableAsync<TodoItem>();
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


