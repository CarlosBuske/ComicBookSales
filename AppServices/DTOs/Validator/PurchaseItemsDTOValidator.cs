using AppServices.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTOs.Validator
{
    public class PurchaseItemsDTOValidator : AbstractValidator<PurchaseItemsDTO>
    {
        public PurchaseItemsDTOValidator()
        {
            RuleFor(x => x.IdComicBook)
                .NotEmpty()
                .NotNull()
                .Equal(0)
                .WithMessage("Produto deve ser informado!");

            RuleFor(x => x.UnitValue)
                .NotEmpty()
                .NotNull()
                .Equal(0)
                .WithMessage("Valor unitario invalido!");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .NotNull()
                .Equal(0)
                .WithMessage("Quantidade invalida!");
        }
    }
}
