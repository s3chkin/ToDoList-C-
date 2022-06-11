using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_1.Buisness;
using ToDoList_1.Data;

namespace ToDoList_1.Presentation
{
    class Display
    {
        private int closeOperationId = 6;
        private ToDoListBuisness toDoListBuisness = new ToDoListBuisness();
        public Display()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all tasks");
            Console.WriteLine("2. Add new task");
            Console.WriteLine("3. Update task");
            Console.WriteLine("4. Fetch task by ID");
            Console.WriteLine("5. Delete task by ID");
            Console.WriteLine("6. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            toDoListBuisness.Delete(id);
            Console.WriteLine("Done.");
        }
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            ListTask listTask = toDoListBuisness.Get(id);
            if (listTask != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + listTask.Id);
                Console.WriteLine("Time: " + listTask.Time);
                Console.WriteLine("TaskName: " + listTask.TaskName);
                Console.WriteLine(new string('-', 40));
            }
        }
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            ListTask listTask = toDoListBuisness.Get(id);
            if (listTask != null)
            {
                Console.WriteLine("Enter days for transmission: ");
                listTask.Time = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter name: ");
                listTask.TaskName = Console.ReadLine();
                toDoListBuisness.Update(listTask);
            }
            else
            {
                Console.WriteLine("Task not found!");
            }
        }
        private void Add()
        {
            ListTask listTask = new ListTask();
            Console.WriteLine("Enter Task Name: ");
            listTask.TaskName = Console.ReadLine();
            Console.WriteLine("Enter days for transmission: ");
            listTask.Time = int.Parse(Console.ReadLine());
            toDoListBuisness.Add(listTask);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Tasks" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var products = toDoListBuisness.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine("{0}. {1} {2} days for transmission!", item.Id, item.TaskName, item.Time);
            }
        }

    }
}
