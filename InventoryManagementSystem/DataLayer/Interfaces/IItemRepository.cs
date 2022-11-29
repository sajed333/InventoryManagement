using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IItemRepository
    {
        bool CreateItem(tbItemMaster item);
        List<Item> GetAllItems();
        tbItemMaster UpdateItem(int itemId, tbItemMaster item);
        List<tbWarehouse> GetWarehouses();

        void DeleteItem(int ItemID);
        List<tbItemMaster> GetWarehouseOneItemsById();
        List<tbItemMaster> GetWarehouseTwoItemsById();
        bool IsExistUniqueNumber(long? uniqueId);

    }
}
