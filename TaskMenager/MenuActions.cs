using System;
using System.Collections.Generic;
using System.Text;
namespace TaskMenager
{
    public class MenuActions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MenuName { get; set; }
        
        public MenuActions(int id)
        {
            Id = id;
        }

        public MenuActions(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public MenuActions()
        {
        }
    }
}