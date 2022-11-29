using BusinessLayer.BusinessLogic;
using BusinessLayer.Interfaces;
using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemBusineddLogic _itemBusineddLogic;
        private readonly Inventory_Management_systeamEntities _context;
        public ItemController()
        {
            _itemBusineddLogic = new ItemBusineddLogic();
            _context = new Inventory_Management_systeamEntities();
        }


        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayItems()
        {
            List<Item> itemsList = _itemBusineddLogic.GetAllItems();
            ViewBag.warehouses = itemsList;
            return View(itemsList);
        }

        [HttpGet]
        public ActionResult CreateItem()
        {
            Item item = new Item();
            item.WarehouseList= _itemBusineddLogic.GetWarehouses();
            ViewBag.warehouses = item.WarehouseList;
            return View(item);
        }

        [HttpPost]
        public ActionResult CreateItem(tbItemMaster tbItem)
        {
            _itemBusineddLogic.CreateItem(tbItem);
            return RedirectToAction("DisplayItems");
        }
        [HttpGet]
        public ActionResult UpdateItem(int itemId)
        {
            
            tbItemMaster iM = _itemBusineddLogic.GetItemById(itemId);
            Item item = new Item
            {
                ItemName = iM.ItemName,
                ItemDescription=iM.ItemDescription,
                WarehouseId=iM.WarehouseId,
               ItemId=iM.ItemId,
               Price=iM.Price,
               StockQty=iM.StockQty,
               Unit=iM.Unit,
               WarehouseList = _itemBusineddLogic.GetWarehouses()
            };
            ViewBag.warehouses = item.WarehouseList;
            return View(item);
        }

        [HttpPost]
        public ActionResult UpdateItem(int itemId, tbItemMaster item)
        {
            _itemBusineddLogic.UpdateItem(itemId, item);
            return RedirectToAction("DisplayItems");
        }
        [HttpGet]
        public ActionResult DeleteItem(int itemId)
        {
            _itemBusineddLogic.DeleteItem(itemId);
            return RedirectToAction("DisplayItems","Item");
        }

        [HttpGet]
        public ActionResult WarehouseOne()
        {
            List<tbItemMaster> itemMaster = _itemBusineddLogic.GetWarehouseOneItemsById();
            List<Item> item = new List<Item>();

            foreach(var i in itemMaster)
            {
                item.Add(new Item
                {
                    ItemDescription=i.ItemDescription,
                    ItemId=i.ItemId,
                    ItemName=i.ItemName,
                    Price=i.Price,
                    StockQty=i.StockQty,
                    Unit=i.Unit,
                    WarehouseId=i.WarehouseId
                });
            }
            return View(item);
        }
        [HttpGet]
        public ActionResult WarehouseTwo()
        {
            List<tbItemMaster> itemMaster = _itemBusineddLogic.GetWarehouseTwoItemsById();
            List<Item> item = new List<Item>();

            foreach (var i in itemMaster)
            {
                item.Add(new Item
                {
                    ItemDescription = i.ItemDescription,
                    ItemId = i.ItemId,
                    ItemName = i.ItemName,
                    Price = i.Price,
                    StockQty = i.StockQty,
                    Unit = i.Unit,
                    WarehouseId = i.WarehouseId
                });
            }
            return View(item);
        }
        [HttpGet]
        public ActionResult EditWarehouseItem(int itemId)
        {
            tbItemMaster iM = _itemBusineddLogic.GetItemById(itemId);
            Item item = new Item
            {
                ItemName = iM.ItemName,
                ItemDescription = iM.ItemDescription,
                WarehouseId = iM.WarehouseId,
                ItemId = iM.ItemId,
                Price = iM.Price,
                StockQty = iM.StockQty,
                Unit = iM.Unit,
                WarehouseList = _itemBusineddLogic.GetWarehouses()
            };
            ViewBag.warehouses = item.WarehouseList;
            return View(item);
        }
        [HttpPost]
        public ActionResult EditWarehouseItem(int itemId,Item editItem)
        {
            string message = string.Empty;
           var oldItem= _itemBusineddLogic.GetItemById(itemId);
            if(editItem.StockQty == oldItem.StockQty)
            {
                tbItemMaster tbItemMaster = new tbItemMaster
                {
                    ItemDescription = editItem.ItemDescription,
                    ItemName=editItem.ItemName,
                    Price=editItem.Price,
                    StockQty=editItem.StockQty,
                    Unit=editItem.Unit,
                    WarehouseId=editItem.WarehouseId
                };

                _itemBusineddLogic.UpdateItem(itemId,tbItemMaster);
            }
            else if(editItem.StockQty > oldItem.StockQty)
            {
                ViewBag.Message = "You have entered more than Stock Quantity";
            }
            else
            {
                int balanceQty = oldItem.StockQty - editItem.StockQty;
                tbItemMaster tbItemMaster = new tbItemMaster
                {
                    ItemDescription = oldItem.ItemDescription,
                    ItemName = oldItem.ItemName,
                    Price = oldItem.Price,
                    StockQty = balanceQty,
                    Unit = oldItem.Unit,
                    WarehouseId = oldItem.WarehouseId
                };

                _itemBusineddLogic.UpdateItem(itemId,tbItemMaster);

                tbItemMaster tbItemMasterToAdd = new tbItemMaster
                {
                    ItemDescription = editItem.ItemDescription,
                    ItemName = editItem.ItemName,
                    Price = editItem.Price,
                    StockQty = editItem.StockQty,
                    Unit = editItem.Unit,
                    WarehouseId = editItem.WarehouseId
                };

                _itemBusineddLogic.CreateItem(tbItemMasterToAdd);
            }
            return RedirectToAction("DisplayItems","Item");
        }
    }
}