using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ItemRepository: IItemRepository
    {
        private readonly Inventory_Management_systeamEntities _context;
        private readonly IGenericRepository<tbItemMaster> itemGeneric;
        public ItemRepository()
        {
            this._context = new Inventory_Management_systeamEntities();
            this.itemGeneric = new GenericRepository<tbItemMaster>();
        }
        public bool CreateItem(tbItemMaster item)
        {
            bool isCreated = false;
            if (item != null)
            {
                try
                {
                    _context.tbItemMasters.Add(item);
                    _context.SaveChanges();
                    isCreated = true;
                }
                catch (Exception ex)
                {
                    return isCreated;
                }
            }

            return isCreated;
        }
        public List<Item> GetAllItems()
        {
            List<tbItemMaster> items = _context.tbItemMasters.OrderByDescending(m=>m.ItemId).ToList();
            List<Item> dbItem = new List<Item>();
            foreach (var d in items)
            {if (d.WarehouseId > 0)
                {
                    var warehouse = _context.tbWarehouses.FirstOrDefault(m => m.WarehouseId == d.WarehouseId).WarehouseDescription;
                    dbItem.Add(new Item {
                        ItemId = d.ItemId,
                        ItemDescription = d.ItemDescription,
                        ItemName = d.ItemName,
                        Price = d.Price,
                        StockQty = d.StockQty,
                        Unit = d.Unit,
                        Warehouse=warehouse,
                        WarehouseId=d.WarehouseId,
                        UniqueId=d.UniqueId,
                    });
                }
            }
            return dbItem;
        }
        public tbItemMaster UpdateItem(int itemId,tbItemMaster item)
        {
            tbItemMaster itemById = _context.tbItemMasters.Where(m => m.ItemId == itemId).FirstOrDefault();
            itemById.ItemName = item.ItemName;
            itemById.ItemDescription = item.ItemDescription;
            itemById.Price = item.Price;
            itemById.StockQty = item.StockQty;
            itemById.WarehouseId = item.WarehouseId;
            _context.SaveChanges();
            return itemById;
            
        } 

        public List<tbWarehouse> GetWarehouses()
        {
           return _context.tbWarehouses.ToList();
            
        }
        public void DeleteItem(int ItemID)
        {
            tbItemMaster tbItem = _context.tbItemMasters.Find(ItemID);
            _context.tbItemMasters.Remove(tbItem);
            _context.SaveChanges();
        }

        public List<tbItemMaster> GetWarehouseOneItemsById()
        {
            //have harcodes for first warehouse
            List<tbItemMaster> warehouseData = _context.tbItemMasters.Where(m=>m.WarehouseId==1).OrderByDescending(m => m.WarehouseId).ToList();
            return warehouseData;
        }
        public List<tbItemMaster> GetWarehouseTwoItemsById()
        {
            //have harcodes for first warehouse
            List<tbItemMaster> warehouseData = _context.tbItemMasters.Where(m => m.WarehouseId == 2).OrderByDescending(m => m.WarehouseId).ToList();
            return warehouseData;
        }
        public bool IsExistUniqueNumber(long? uniqueId)
        {
         return  _context.tbItemMasters.Any(m => m.UniqueId == uniqueId);
        }
    }
}
