using Application.Dto;
using AutoMapper;
using Domain.Orders;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MappingProfile
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserAddress,UserAddressDto>();
            CreateMap<AddUserAddressDto,UserAddress>();
            CreateMap<UserAddress,Address>();
        }
    }
}
