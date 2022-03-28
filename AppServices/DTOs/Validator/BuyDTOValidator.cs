using AppServices.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs.Validator
{
    public class BuyDTOValidator : AbstractValidator<BuyDTO>
    {
        public BuyDTOValidator()
        {
            RuleFor(x => x.IdUser)
                .NotEmpty()
                .NotNull()
                .Equal(0)
                .WithMessage("Usuario deve estar logado para realizar a compra!");

            RuleFor(x => x.TotalValue)
                .NotEmpty()
                .NotNull()
                .Equal(0)
                .WithMessage("Valor total invalido!");
        }
    }
}
