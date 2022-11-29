using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IItemBusineddLogic
    {
        bool CreateItem(tbItemMaster item);
        List<Item> GetAllItems();
        tbItemMaster UpdateItem(int itemId, tbItemMaster item);
        tbItemMaster GetItemById(int itemId); 
        List<tbWarehouse> GetWarehouses();
        void DeleteItem(int itemId);
        List<tbItemMaster> GetWarehouseTwoItemsById();
        List<tbItemMaster> GetWarehouseOneItemsById();
    }
}
