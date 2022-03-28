using AppServices.DTO;
using AppServices.DTOs;
using AppServices.DTOs.Validator;
using AppServices.Services.Interface;
using AppServices.Utility;
using AutoMapper;
using Domain.Account;
using Domain.Entities;
using Domain.Repository.Interface;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public class BuyService : IBuyService
    {
        private readonly IBuyRepository _buyRepository;
        private readonly IComicBookRepository _comicbookRepository;
        private readonly IMapper _mapper;

        private readonly string VALID_USER_TYPE_CHECKOUT = "NORMAL";

        public BuyService(IMapper mapper, IBuyRepository buyRepository, IComicBookRepository comicbookRepository)
        {
            _buyRepository = buyRepository;
            _comicbookRepository = comicbookRepository;
            _mapper = mapper;
        }

        public async Task<ResultServices> Checkout(CheckoutDTO CheckoutDTO)
        {


            var resultCheckout = ValidateCheckout(CheckoutDTO);
            if (!resultCheckout.IsValid)
                return ResultServices.RequestError("Problemas na validação!", resultCheckout);

            var resultPurchaseItems = ValidateCheckoutItems(CheckoutDTO.PurchaseItems);
            var validatePurchaseItem = resultPurchaseItems != null && !resultPurchaseItems.IsValid;
            if (validatePurchaseItem)
                return ResultServices.RequestError("Problemas na validação em produtos da compra!", resultPurchaseItems);


            var resultValidateStock = ValidateStockItems(CheckoutDTO.PurchaseItems);
            if (!resultValidateStock.Result.IsSuccess)
                return ResultServices.Fail(resultValidateStock.Result.Message);

            var checkout = _mapper.Map<Buy>(CheckoutDTO);
            await _buyRepository.InsertBuyAsync(checkout);

            return ResultServices.Ok("Compra finalizada!");
        }


        protected ValidationResult ValidateCheckout(CheckoutDTO checkoutDTO)
        {
            var result = new CheckoutDTOValidator().Validate(checkoutDTO);
            return result;
        }

        protected ValidationResult ValidateCheckoutItems(List<PurchaseItemsDTO> purchaseItemsDTO)
        {

            foreach (var item in purchaseItemsDTO)
            {
                var result = new PurchaseItemsDTOValidator().Validate(item);
                if (!result.IsValid)
                    return result;
            }
            return null;
        }

        protected async Task<ResultServices> ValidateStockItems(List<PurchaseItemsDTO> purchaseItemsDTO)
        {
            var purchaseItemsDTODistinct = purchaseItemsDTO.GroupBy(g => g.Id);
            foreach (var item in purchaseItemsDTO)
            {
                var totalItems = purchaseItemsDTO.Where(w => w.Id == item.Id).Sum(s => s.Quantity);
                var Item = await _comicbookRepository.GetById(item.Id);
                var InvalidStock = totalItems > Item.Stock;
                if (InvalidStock)
                    return ResultServices.Fail(String.Format("O produto [0] não possui estoque!", Item.Description));
            }

            return ResultServices.Ok("Produtos validos");
        }


    }
}
