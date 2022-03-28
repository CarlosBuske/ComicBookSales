using Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ComicBook
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? PublicationDate { get; private set; }
        public decimal? Price { get; private set; }
        public string Author { get; private set; }
        public int? Stock { get; private set; }

        [NotMapped]
        public ICollection<PurchaseItems> PurchaseItems { get; private set; }

        public ComicBook()
        {

        }

        public ComicBook(string title, string description, DateTime? publicationDate, decimal? price, string author, int? stock)
        {
            Validation(title, description, publicationDate, price, author, stock);

            Title = title;
            Description = description;
            PublicationDate = publicationDate;
            Price = price;
            Stock = stock;
            Author = author;
        }

        private void Validation(string title, string description, DateTime? publicationDate, decimal? price, string author, int? stock)
        {
            ValidationException.When(string.IsNullOrEmpty(title), "Titulo deve ser informado!");
            ValidationException.When(string.IsNullOrEmpty(description), "Descrição deve ser informado!");
            ValidationException.When(!publicationDate.HasValue, "Data publicação deve ser informada!");
            ValidationException.When(!price.HasValue, "Preço deve ser informado!");
            ValidationException.When(!stock.HasValue, "Estoque deve ser informado!");
            ValidationException.When(string.IsNullOrEmpty(author), "Autor deve ser informado!");
        }
    }
}
