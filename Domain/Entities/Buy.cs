using Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Buy
    {
        public  int Id { get; private set; }
        public  int IdUser { get; private set; }
        public  decimal TotalValue { get; private set; }
        public  DateTime Date { get; private set; }

        [NotMapped]
        public ICollection<PurchaseItems> PurchaseItems { get; private set; }

        public Buy()
        {

        }
        public Buy(int iduser, decimal totalvalue, DateTime date, List<PurchaseItems> purchaseItems)
        {
            Validation(iduser, totalvalue);

            IdUser = iduser;
            TotalValue = totalvalue;
            Date = DateTime.Now;
            PurchaseItems = purchaseItems;
        }

        private void Validation(int iduser, decimal totalvalue)
        {
            ValidationException.When(totalvalue <= 0, "Valor total incorreto!");
        }
    }
}
