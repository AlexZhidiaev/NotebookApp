using NotebookApp;
using NotebookApp.Models;
using NUnit.Framework;
using System;


namespace NoteBookAppTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            TodoItem todoItem = new TodoItem();
            todoItem.ID = 1;
            todoItem.UserName = "string>";
            todoItem.Notes = "do smth";
            todoItem.Done = true;
            TodoItem secondTodoItem = todoItem;
            Assert.IsTrue(todoItem.Equals(secondTodoItem));
        }
    }
    
}