using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace NotebookApp.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }
}
