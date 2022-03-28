using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTO
{
    public class PurchaseItemsDTO
    {
        public int Id { get; set; }
        public int IdComicBook { get; set; }
        public int IdBuy { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
    }
}
