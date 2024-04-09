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
        bool Success;
        var task = new List<Task>();
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
                    Success = int.TryParse(_TaskId, out TaskId);
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
                            task.Add(taskService.AddNewTask(TaskId, TaskName, TaskDescription, TaskDeadline, TaskCategory));
                            
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
                    for (int i = 0;i < task.Count;i++)
                    {
                        Console.WriteLine(task[i].Id + task[i].Name);
                    }
                    Console.WriteLine("Select task by inserting task id:");
                    string _TaskIdView = Console.ReadLine();
                    int TaskIdView;
                    Success = int.TryParse(_TaskIdView, out TaskIdView);
                    if(Success == true)
                    {
                        Console.WriteLine("What you wanna do with this task?");
                        var OpperationList = actionsService.GetMenuActionByMenuName("Opperation");
                        for(int i = 0;i < OpperationList.Count;i++)
                        {
                            Console.WriteLine(OpperationList[i].Name);
                        }
                        string _Opperation = Console.ReadLine();
                        int Opperation;
                        Success = int.TryParse(_Opperation, out Opperation);
                        if(Success == true)
                        {
                            Console.WriteLine("What you wanna edit?");
                            var EditList = actionsService.GetMenuActionByMenuName("Edit");
                            for(int i = 0;i < EditList.Count;i++)
                            {
                                Console.WriteLine($"{EditList[i].Name}");
                            }
                            string _EditChoose = Console.ReadLine();
                            int EditChoose;
                            Success = int.TryParse(_EditChoose, out EditChoose);
                            if(Success == true)
                            {
                                switch (EditChoose)
                                {
                                    case 1:
                                        Console.WriteLine("Insert new Id");
                                        string _NewId = Console.ReadLine();
                                        int NewId;
                                        Success = int.TryParse(_NewId, out NewId);
                                        if(Success == true)
                                        {
                                            task[TaskIdView].Id = NewId;
                                            Console.WriteLine("New id was succesful updated.");
                                        }
                                        break;
                                    case 2:
                                        Console.WriteLine("Insert new Name");
                                        string NewName = Console.ReadLine();
                                        if (Success == true)
                                        {
                                            task[TaskIdView].Name = NewName;
                                            Console.WriteLine("New name was succesful updated.");
                                        }
                                        break;
                                    case 3:
                                        Console.WriteLine("Insert new Description");
                                        string NewDescription= Console.ReadLine();
                                        if (Success == true)
                                        {
                                            task[TaskIdView].Description = NewDescription;
                                            Console.WriteLine("New description was succesful updated.");
                                        }
                                        break;
                                    case 4:
                                        Console.WriteLine("Insert new Deadline");
                                        string NewDeadline = Console.ReadLine();
                                        if (Success == true)
                                        {
                                            task[TaskIdView].Deadline = NewDeadline;
                                            Console.WriteLine("New Deadline was succesful updated.");
                                        }
                                        break;
                                    case 5:
                                        Console.WriteLine("insert new category:");
                                        var NewCategoryView = actionsService.GetMenuActionByMenuName("Category");
                                        for(int i = 0; i < NewCategoryView.Count;i++)
                                        {
                                            Console.WriteLine(NewCategoryView[i].Name);
                                        }
                                        string _NewCategory = Console.ReadLine();
                                        int NewCategory;
                                        int.TryParse(_NewCategory, out NewCategory);
                                        switch(NewCategory) 
                                        {
                                            case 1:
                                                task[TaskIdView].Category = "Home";
                                                Console.WriteLine("New Category was succesful updated.");
                                                break;
                                            case 2:
                                                task[TaskIdView].Category = "Job";
                                                Console.WriteLine("New Category was succesful updated.");
                                                break;
                                            case 3:
                                                task[TaskIdView].Category = "Hobby";
                                                Console.WriteLine("New Category was succesful updated.");
                                                break;
                                            default:
                                                Console.WriteLine("Wrong category id!!");
                                                break;
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Wrong element id!!!");
                                        break;
                                }
                            }
                        }
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