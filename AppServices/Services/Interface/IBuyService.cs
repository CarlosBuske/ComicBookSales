using AppServices.DTO;
using AppServices.DTOs;
using AppServices.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.Interface
{
    public interface IBuyService
    {
        Task<ResultServices> Checkout(CheckoutDTO buyDTO, int idUser);

    }
}
