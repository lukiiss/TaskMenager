﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//BŁĘDY
//1.Wyoisuje dwa razy ten sam obiekt
//2.Niedziała edycja id
//3.Niemożna dodać drugiego obiektu
//Plan:
//Rozdzielić rzeczy w programie na poszczególne metody
//A następnie znaleść błędy
namespace TaskMenager
{
    public class TaskService
    {
        public static string NumberToCategory(int number)
        {
            string category = "none";
            switch(number)
            {
                case 1:
                    category = "Home";
                    break;
                case 2:
                    category = "Work";
                    break;
                case 3:
                    category = "Hobby";
                    break;
            }
            return category;
        }
        private List<Task> tasks= new List<Task>();
        public Task AddNewTask(string name, string description,string deadline, string category)
        {
            int tasksCount = tasks.Count;
            int lastId = 0;
            if (tasksCount > 0)
            {
                lastId = tasks[tasksCount - 1].Id;
            }
            int nextId = lastId + 1;
            Task task = new Task() { Id = nextId, Name = name, Description = description,Deadline = deadline,Category = category };
            tasks.Add(task);
            return task;
        }
        List<Task> SelectedTask = new List<Task>();
        public List<Task> AllTasks()
        {
            TaskService taskService = new TaskService();
            foreach(Task element in  tasks) 
            {   
                    SelectedTask.Add(element);
            }
            return SelectedTask;
        }
        public void RemoveTask(int RemoveId)
        {
            Task TaskToRemove = new Task();
            foreach (var task in tasks)
            {
                if (task.Id == RemoveId)
                {
                    TaskToRemove = task;
                    break;
                }
            }
            tasks.Remove(TaskToRemove);
        }
    }
}
