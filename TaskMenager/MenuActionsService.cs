using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenager
{
    public class MenuActionsService
    {
        private List<MenuActions> menuactions = new List<MenuActions> ();
        public MenuActions NewMenuAction(int id,string name,string menuName)
        {
            MenuActions menuaction = new MenuActions() { Id = id, Name = name, MenuName = menuName };
            menuactions.Add(menuaction);
            return menuaction;
        }
        public List<MenuActions> GetMenuActionByMenuName(string menuname) 
        {
            List<MenuActions> elements = new List<MenuActions>();
            foreach (MenuActions element in menuactions)
            { 
                if(element.MenuName == menuname)
                {
                    elements.Add(element);
                }
            }
            return elements;
        }
    }
}
