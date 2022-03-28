using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTO
{
    public class BuyDTO
    {
        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public decimal TotalValue { get; private set; }
        public DateTime Date { get; private set; }
        public virtual UserDTO User { get; private set; }
        public List<PurchaseItems> PurchaseItems { get; private set; }
    }
}
