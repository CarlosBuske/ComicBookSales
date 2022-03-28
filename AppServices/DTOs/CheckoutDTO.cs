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
        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public decimal TotalValue { get; private set; }
        public DateTime Date { get; private set; }
        public List<PurchaseItemsDTO> PurchaseItems { get; private set; }
    }
}
