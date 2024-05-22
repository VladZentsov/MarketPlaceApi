using AutoMapper;
using MarketPlaceBLL.DTOs;
using MarketPlaceBLL.Models;
using MarketPlaceDAL.Entities;
using MarketPlaceDAL.Repositories;
using MarketPlaceDAL.UoW;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceBLL.Services
{
    public class UserService: MarketService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserService(IMapper mapper, IUnitOfWork unitOfWork, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : base(mapper, unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<UserDto> GetUserDtoByIdAsync(string userId)
        {
            var userRepo = _unitOfWork.GetUserRepository();
            var user = await userRepo.GetByIdWithDetailsAsync(userId);
            var role = await _userManager.GetRolesAsync(user);
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Roles = role.ToList();

            if (user.Shops!=null || user.Shops.Count > 0)
            {
                userDto.ShopId = user.Shops.FirstOrDefault().Id;
            }

            return userDto;
        }
        public async Task AddRoleToUser(AddRoleModel addRoleModel)
        {
            var user = await GetUserByIdAsync(addRoleModel.UserId);
            var roleExists = await _roleManager.RoleExistsAsync(addRoleModel.Role);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole(addRoleModel.Role));
            }
            await _userManager.AddToRoleAsync(user, addRoleModel.Role);
        }

        private async Task<User> GetUserByIdAsync(string userId)
        {
            var userRepo = _unitOfWork.GetUserRepository();
            var user = await userRepo.GetByIdAsync(userId);

            return user;
        }
    }
}
