using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal Price { get; set; }
        public int Unit { get; set; }
        public int WarehouseId { get; set; }
        public int StockQty { get; set; }
        public string Warehouse { get; set; }
        [NotMapped]
        public List<tbWarehouse> WarehouseList { get; set; }
        public long? UniqueId { get; set; }

    }
}