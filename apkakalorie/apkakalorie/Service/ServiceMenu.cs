using apkakalorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apkakalorie.Service
{
    public class ServiceMenu
    {
        List<Menu> menus = new List<Menu>();

        public int ShowMenu() {
        
            Console.WriteLine("Wprowadz numer opcji, która chcesz wykonac");

            foreach (var menu in menus)
            {
                Console.WriteLine($"{menu.Id} : {menu.Name}");
            }

            string input = Console.ReadLine();
            Int32.TryParse(input, out int inputNumber);

            return inputNumber;
        }

        public void AddMenuToList(int id, string name) {

            menus.Add(new Menu { Id = id, Name = name });

        }
    }
}
