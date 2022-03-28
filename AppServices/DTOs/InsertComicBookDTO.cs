using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs
{
    public class InsertComicBookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublicationDate { get; set; }
        public decimal? Price { get; set; }
        public string Author { get; set; }
        public int? Stock { get; set; }
    }
}
