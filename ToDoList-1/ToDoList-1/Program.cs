using Microsoft.EntityFrameworkCore;
using System;
using ToDoList_1.Data;
using ToDoList_1.Presentation;

namespace ToDoList_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToDoListContext db = new ToDoListContext();
            db.Database.Migrate();
            Display d = new Display();
        }
    }
}
