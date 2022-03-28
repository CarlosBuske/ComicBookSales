using Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class UserType
    {
        public int Id { get; private set; }
        public string Cod { get; private set; }
        public string Description { get; private set; }

        [NotMapped]
        public ICollection<User> Users { get; private set; }

        public UserType()
        {

        }

        public UserType(string cod, string description)
        {
            Validation(cod, description);

            Cod = cod;
            Description = description;
        }

        private void Validation(string cod, string description)
        {
            ValidationException.When(string.IsNullOrEmpty(cod), "Codigo deve ser informado!");
            ValidationException.When(string.IsNullOrEmpty(description), "Descrição deve ser informada!");

        }
    }
}
