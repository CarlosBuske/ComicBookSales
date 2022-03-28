using Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PurchaseItems
    {
        public int Id { get; private set; }
        public int IdComicBook { get; private set; }
        public int IdBuy { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitValue { get; private set; }
        public virtual ComicBook comicbook { get; private set; }
        public virtual Buy buy { get; private set; }

        public PurchaseItems()
        {

        }

        public PurchaseItems(int idcomicbook, int idbuy, int quantity, decimal unitvalue, ComicBook Comicbook, Buy Buy)
        {
            Validation(idcomicbook, unitvalue, quantity );

            IdComicBook = idcomicbook;
            IdBuy = idbuy;
            Quantity = quantity;
            UnitValue = unitvalue;
            comicbook = Comicbook;
            buy = Buy;
        }

        private void Validation(int idcomicbook, decimal unitvalue, int quantity)
        {
            ValidationException.When(idcomicbook <= 0, "Quadrinho deve ser informado!");
            ValidationException.When(unitvalue <= 0, "Valor unitario incorreto!");
            ValidationException.When(quantity <= 0, "Quantidade incorreta!");
        }
    }
}
