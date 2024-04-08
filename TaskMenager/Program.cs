using System.Runtime.CompilerServices;
using System.Security.Cryptography;
namespace TaskMenager;
public class Program
{
    static void Main(string[] args)
    {
        //c wyjście z programu
        //c1 użytkownik zostanie pożegnany a program sie zamknie
        MenuActionsService actionsService = new MenuActionsService();
        actionsService = Initalize(actionsService);
        TaskService taskService = new TaskService();
        Console.WriteLine("Welcome to TaskMenager!!");
        bool IsContinue = true;
        List<Task> task = new List<Task>();
        while (IsContinue == true)
        {
            Console.WriteLine("Select below what you wanna do.");
            var MainMenu = actionsService.GetMenuActionByMenuName("Main");
            for (int i = 0; i < MainMenu.Count; i++)
            {
                Console.WriteLine($"{MainMenu[i].Name}");
            }
            var MainOperation = Console.ReadLine();
                switch (MainOperation)
            {
                case "1":
                    Console.WriteLine("Insert task id:");
                    var _TaskId = Console.ReadLine();
                    int TaskId;
                    bool Success = int.TryParse(_TaskId, out TaskId);
                    if (Success == true)
                    {
                        Console.WriteLine("Insert task name:");
                        string TaskName = Console.ReadLine();
                        Console.WriteLine("Insert task description:");
                        string TaskDescription = Console.ReadLine();
                        Console.WriteLine("Insert task deadline(HH:MM/DD/MM/YYYY):");
                        string TaskDeadline = Console.ReadLine();
                        Console.WriteLine("Select task category:");
                        var Category = actionsService.GetMenuActionByMenuName("Category");
                        for (int i = 0; i < Category.Count; i++)
                        {
                            Console.WriteLine($"{Category[i].Name}");
                        }
                        string __TaskCategory = Console.ReadLine();
                        int _TaskCategory;
                        int.TryParse(__TaskCategory, out _TaskCategory);
                        string TaskCategory = TaskService.NumberToCategory(_TaskCategory);
                        if (_TaskCategory < 4 && _TaskCategory > 0)
                        {
                            Console.WriteLine($"You created new task named {TaskName}");
                            taskService.AddNewTask(TaskId, TaskName, TaskDescription, TaskDeadline, TaskCategory);
                        }
                        else
                        {
                            Console.WriteLine("Wrong Category number!!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("id must be a number!!!");
                    }
                    break;
                case "2":
                    task = taskService.AllTasks();
                    Console.WriteLine("----------------------------------");
                    for(int i = 0;i < task.Count;i++)
                    {
                        Console.WriteLine($"{task[i].Id}.{task[i].Name}");
                    }
                    Console.WriteLine("Insert id of the task you want to see:");
                    string __TaskIdOperation = Console.ReadLine();
                    int TaskIdOperation;
                    int.TryParse(__TaskIdOperation, out TaskIdOperation);
                    int index = 0;
                    foreach (Task element in task)
                    {
                        if (element.Id == TaskIdOperation)
                        {
                            Console.WriteLine($"Id-{task[index].Id}, Name-{task[index].Name}, Description-{task[index].Description} , Deadline-{task[index].Deadline}, Category-{task[index].Category}");
                            Console.WriteLine("What you wanna do? Select operation below.");
                            var Opperation = actionsService.GetMenuActionByMenuName("Opperation");
                            for (int i = 0; i < Opperation.Count; i++)
                            {
                                Console.WriteLine($"{Opperation[i].Name}");
                            }
                            string _TaskOperation = Console.ReadLine();
                            int TaskOperation;
                            int.TryParse(_TaskOperation, out TaskOperation);
                            switch (TaskOperation)
                            {
                                case 1:
                                    Console.WriteLine("What you wanna edit?");
                                    var edit = actionsService.GetMenuActionByMenuName("Edit");
                                    for (int i = 0; i < edit.Count; i++)
                                    {
                                        Console.WriteLine($"{edit[i].Name}");
                                    }
                                    string _TaskElement = Console.ReadLine();
                                    int TaskElement;
                                    int.TryParse(_TaskElement, out TaskElement);
                                    string NewData;
                                    int _NewData;
                                    switch (TaskElement)
                                    {
                                        case 1:
                                            Console.WriteLine("Insert new Id:");
                                            NewData = Console.ReadLine();
                                            int.TryParse(NewData, out _NewData);
                                            task[index].Id = _NewData;
                                            break;
                                        case 2:
                                            Console.WriteLine("Insert new Name:");
                                            NewData = Console.ReadLine();
                                            task[index].Name = NewData;
                                            break;
                                        case 3:
                                            Console.WriteLine("Insert new Description:");
                                            NewData = Console.ReadLine();
                                            task[index].Description = NewData;
                                            break;
                                        case 4:
                                            Console.WriteLine("Insert new Deadline(HH:MM/DD/MM/YYYY):");
                                            NewData = Console.ReadLine();
                                            task[index].Deadline = NewData;
                                            break;
                                        case 5:
                                            Console.WriteLine("Select new category:");
                                            var Category = actionsService.GetMenuActionByMenuName("Category");
                                            for (int i = 0; i < Category.Count; i++)
                                            {
                                                Console.WriteLine($"{Category[i].Name}");
                                            }
                                            NewData = Console.ReadLine();
                                            int.TryParse(NewData, out _NewData);
                                            task[index].Category = TaskService.NumberToCategory(_NewData);
                                            break;
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine($"Are you sure that you want delete task named {task[index].Name}? Y/N");
                                    var DeleteDecision = Console.ReadKey();
                                    switch (DeleteDecision.KeyChar)
                                    {
                                        case 'Y':
                                            taskService.RemoveTask(index);
                                            break;
                                    }
                                    break;
                            }
                        }
                    index++;
                    }
                    
                        
                    
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    IsContinue = false;
                    break;
                    
            }
        }
        static MenuActionsService Initalize(MenuActionsService actionsService)
        {
            actionsService.NewMenuAction(1, "1.Create new task", "Main");
            actionsService.NewMenuAction(2, "2.See Task", "Main");
            actionsService.NewMenuAction(3, "3.Exit", "Main");
            actionsService.NewMenuAction(4, "1.Home", "Category");
            actionsService.NewMenuAction(5, "2.Job", "Category");
            actionsService.NewMenuAction(6, "3.Hobby", "Category");
            actionsService.NewMenuAction(7, "1.Edit", "Opperation");
            actionsService.NewMenuAction(8, "2.Delete", "Opperation");
            actionsService.NewMenuAction(9, "3.Leave", "Opperation");
            actionsService.NewMenuAction(10, "1.Id", "Edit");
            actionsService.NewMenuAction(11, "2.Name", "Edit");
            actionsService.NewMenuAction(12, "3.Description", "Edit");
            actionsService.NewMenuAction(13, "4.Deadline", "Edit");
            actionsService.NewMenuAction(14, "5.Category", "Edit");
            return actionsService;
        }
    }
}