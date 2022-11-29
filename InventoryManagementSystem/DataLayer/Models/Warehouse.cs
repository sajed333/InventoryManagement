using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public string WarehouseDescription { get; set; }
        public bool IsActive { get; set; }
    }
}
