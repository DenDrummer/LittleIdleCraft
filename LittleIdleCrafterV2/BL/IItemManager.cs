using LIC.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIC.BL
{
    public interface IItemManager
    {
        IEnumerable<Item> GetItems();
        Item GetItem(int id);
        int FindItem(string name);
        Item ResearchItem(int id1, int id2);

        IEnumerable<Item> GetParents(int id);
        IEnumerable<Item> GetChildren(int id);

        IEnumerable<Crafter> GetCrafters();
        Crafter GetCrafter(int id);
    }
}
