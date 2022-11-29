using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessLogic
{
    public class ItemBusineddLogic :IItemBusineddLogic
    {
        private readonly IItemRepository _itemRepository;
        private readonly IGenericRepository<tbItemMaster> itemGeneric;

        public ItemBusineddLogic()
        {
            _itemRepository =new  ItemRepository();
            itemGeneric = new GenericRepository<tbItemMaster>();
        }
        public bool CreateItem(tbItemMaster item)
        {
            
            Random generator = new Random();
            String r = generator.Next(0, 1000000).ToString("D6");
            bool isExist = IsExistUniqueNumber(Convert.ToInt32(r));
            
            while (isExist)
            {
                r = generator.Next(0, 1000000).ToString("D6");
                isExist = IsExistUniqueNumber(Convert.ToInt32(r));
            }
            item.UniqueId = Convert.ToInt32(r);

            return _itemRepository.CreateItem(item);
        }
        public List<Item> GetAllItems()
        {
            return _itemRepository.GetAllItems();
        }
        public tbItemMaster UpdateItem(int itemId, tbItemMaster item)
        {
            return _itemRepository.UpdateItem(itemId,item);
        }
        public tbItemMaster GetItemById(int itemId)
        {
            return itemGeneric.GetById(itemId);
        }
        public List<tbWarehouse> GetWarehouses()
        {
            return _itemRepository.GetWarehouses();
        }
        public void DeleteItem(int itemId)
        {
            _itemRepository.DeleteItem(itemId);
        }
        public List<tbItemMaster> GetWarehouseOneItemsById()
        {
           return _itemRepository.GetWarehouseOneItemsById();
        }
        public List<tbItemMaster> GetWarehouseTwoItemsById()
        {
            return _itemRepository.GetWarehouseTwoItemsById();
        }
        public bool IsExistUniqueNumber(long? uniqueId)
        {
            return _itemRepository.IsExistUniqueNumber(uniqueId);
        }

    }
}
