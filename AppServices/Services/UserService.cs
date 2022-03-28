using AppServices.DTO;
using AppServices.DTO.Validator;
using AppServices.DTOs;
using AppServices.DTOs.Validator;
using AppServices.Services.Interface;
using AppServices.Utility;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interface;
using Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository, IUserTypeRepository usertypeRepository)
        {
            _userRepository = userRepository;
            _userTypeRepository = usertypeRepository;
            _mapper = mapper;
        }

        public async Task<ResultServices<UserDTO>> CreateOrUpdateAsync(InsertUserDTO userDTO)
        {
            if (userDTO == null)
                return ResultServices.Fail<UserDTO>("Objeto deve ser informado!");

            var result = new InsertUserDTOValidator().Validate(userDTO);
            if (!result.IsValid)
                return ResultServices.RequestError<UserDTO>("Problemas na validação!", result);

            var validUserType = ValidateUserType(userDTO.IdUserType);
            if (!validUserType)
                return ResultServices.Fail<UserDTO>("Tipo de usuario invalido!");

            var user = _mapper.Map<User>(userDTO);
            await _userRepository.CreateOrUpdateAsync(user);

            return ResultServices.Ok<UserDTO>(_mapper.Map<UserDTO>(user));
        }

        public async Task<ResultServices<UserDTO>> LoginAsync(string email, string password)
        {
            var emailOrPasswordEmpty = string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password);

            if (emailOrPasswordEmpty)
                return ResultServices.Fail<UserDTO>("Email ou senha não informado!");

            var loggedUser = await _userRepository.FindUserByEmailAndPassword(email, password);

            var userNotFound = loggedUser == null;
            if (userNotFound)
                return ResultServices.Fail<UserDTO>("Usuario não encontrado!");

            return ResultServices.Ok<UserDTO>(_mapper.Map<UserDTO>(loggedUser));
        }

        protected bool ValidateUserType(int idUserType)
        {
            var userType = _userTypeRepository.GetById(idUserType);

            var validUserType = userType != null;

            return validUserType;
        }
    }
}
