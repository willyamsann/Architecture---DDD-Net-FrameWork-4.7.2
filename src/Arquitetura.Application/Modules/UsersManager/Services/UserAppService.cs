using AutoMapper;
using Arquitetura.Application.Modules.UsersManager.Interfaces;
using Arquitetura.Application.Modules.UsersManager.ViewModels;
using Arquitetura.Domain.Modules.UsersManager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitetura.Application.Modules.UsersManager.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserViewModel GetById(string id)
        {
            var user = _userRepository.GetById(id);

            return Mapper.Map<UserViewModel>(user);
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            var users = _userRepository.GetAll();

            return Mapper.Map<IEnumerable<UserViewModel>>(users);
        }

        public IEnumerable<UserViewModel> GetAllPaged(int skip, int take)
        {
            var users = _userRepository.GetAllPaged(skip, take);
            
            return Mapper.Map<IEnumerable<UserViewModel>>(users);
        }

        public IEnumerable<UserViewModel> GetUsersBySpecificPermission(string claimType, string claimValue)
        {
            var users = _userRepository.GetUsersBySpecificPermission(claimType, claimValue);

            return Mapper.Map<IEnumerable<UserViewModel>>(users);
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}
