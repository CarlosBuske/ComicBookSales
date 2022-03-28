using Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int IdUserType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual UserType UserType { get; set; }

        [NotMapped]
        public List<Buy> Buy { get; set; }

        public User()
        {

        }

        public User (int idUserType, string name, string email, string password) 
        {
            Validation(idUserType, name, email, password);

            Name = name;
            Email = email;
            Password = password;
            IdUserType = idUserType;
        }

        private void Validation(int idUserType, string name, string email, string password)
        {
            ValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado!");
            ValidationException.When(string.IsNullOrEmpty(email), "Email deve ser informado!");
            ValidationException.When(string.IsNullOrEmpty(password), "Senha deve ser informada!");
            ValidationException.When(idUserType <= 0, "Tipo usuario deve ser informado!");

        }
    }
}
