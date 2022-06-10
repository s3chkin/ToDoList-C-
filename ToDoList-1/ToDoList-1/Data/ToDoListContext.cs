using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_1.Data.Models;

namespace ToDoList_1.Data
{

    public class ToDoListContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=ToDoListDb; Integrated Security=true");
        }

        public DbSet<ListTask> ListTasks { get; set; }
        public DbSet<ClientDescription> ClientDescriptions { get; set; }


    }

}
