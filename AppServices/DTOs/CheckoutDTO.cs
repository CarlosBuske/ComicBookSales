using AppServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs
{
    public class CheckoutDTO
    {
        public int Id { get;  set; }
        public int IdUser { get;  set; }
        public decimal TotalValue { get;  set; }
        public DateTime Date { get;  set; }
        public List<PurchaseItemsDTO> PurchaseItems { get;  set; }
    }
}
