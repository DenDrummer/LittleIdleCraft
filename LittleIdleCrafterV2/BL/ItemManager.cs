using System;
using System.Collections.Generic;
using LIC.BL.Domain;

namespace LIC.BL
{
    public class ItemManager : IItemManager
    {
        public int FindItem(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetChildren(int id)
        {
            throw new NotImplementedException();
        }

        public Crafter GetCrafter(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Crafter> GetCrafters()
        {
            throw new NotImplementedException();
        }

        public Item GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetParents(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsResearched(int id)
        {
            throw new NotImplementedException();
        }

        public Item ResearchItem(int id1, int id2)
        {
            throw new NotImplementedException();
        }
    }
}
