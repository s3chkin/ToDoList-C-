using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_1.Data;

namespace ToDoList_1.Buisness
{
     class ToDoListBuisness
    {
        private ToDoListContext toDoListContext;

        public List<ListTask> GetAll()
        {
            using (toDoListContext = new ToDoListContext())
            {
                return toDoListContext.ListTasks.ToList();
            }
        }

        public ListTask Get(int id)
        {
            using (toDoListContext = new ToDoListContext())
            {
                return toDoListContext.ListTasks.Find(id);
            }
        }

        public void Add(ListTask listTask)
        {
            using (toDoListContext = new ToDoListContext())
            {
                toDoListContext.ListTasks.Add(listTask);
                toDoListContext.SaveChanges();

            }
        }

        public void Update(ListTask listTask)
        {
            using (toDoListContext = new ToDoListContext())
            {

                var item = toDoListContext.ListTasks.Find(listTask.Id);
                if (item != null)
                {
                    toDoListContext.Entry(item).CurrentValues.SetValues(listTask);
                    toDoListContext.SaveChanges();
                }

            }


        }
        public void Delete(int id)
        {
            using (toDoListContext = new ToDoListContext())
            {
                var product = toDoListContext.ListTasks.Find(id);
                if (product != null)
                {
                    toDoListContext.ListTasks.Remove(product);
                    toDoListContext.SaveChanges();
                }
            }
        }

    }
}
