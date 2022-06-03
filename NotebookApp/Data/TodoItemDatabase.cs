using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using NotebookApp.Models;
using Xamarin.Essentials;

namespace NotebookApp.Data
{
    internal class TodoItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<TodoItemDatabase> Instance = new AsyncLazy<TodoItemDatabase>(async () =>
        {
            var instance = new TodoItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<TodoItem>();
            return instance;
        });

        public TodoItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<TodoItem>> GetItemsAsync(string login)
        {
            return Database.Table<TodoItem>().Where(i=>i.UserName == login).ToListAsync();
        }

        public Task<List<TodoItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<TodoItem> GetItemAsync(int id,string login)
        {
            return Database.Table<TodoItem>().Where(i => i.ID == id).Where(i=>i.UserName == login).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(TodoItem item)
        {
            item.UserName = Preferences.Get("userEmail", "default");
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(TodoItem item)
        {
            return Database.DeleteAsync(item);
        }
    }
}

