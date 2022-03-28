using AppServices.DTO;
using AppServices.DTOs;
using AppServices.DTOs.Validator;
using AppServices.Services.Interface;
using AppServices.Utility;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IMapper _mapper;

        public UserTypeService(IMapper mapper, IUserTypeRepository usertypeRepository)
        {
            _userTypeRepository = usertypeRepository;
            _mapper = mapper;
        }
        public async Task<ResultServices<UserTypeDTO>> CreateOrUpdateAsync(InsertUserTypeDTO userType)
        {
            if (userType == null)
                return ResultServices.Fail<UserTypeDTO>("Objeto deve ser informado!");

            var result = new InsertUserTypeDTOValidator().Validate(userType);
            if (!result.IsValid)
                return ResultServices.RequestError<UserTypeDTO>("Problemas na validação!", result);

            var usertype = _mapper.Map<UserType>(userType);
            await _userTypeRepository.CreateOrUpdateAsync(usertype);

            return ResultServices.Ok<UserTypeDTO>(_mapper.Map<UserTypeDTO>(usertype));
        }
    }
}
