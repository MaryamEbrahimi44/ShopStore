using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application._services
{
    public class UserAddressService:IUserAddressService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;

        public UserAddressService(IDatabaseContext Context, IMapper mapper)
        {
            context = Context;
            this.mapper = mapper;
        }

        public void AddNewAddress(AddUserAddressDto address)
        {
            var data=mapper.Map<UserAddress>(address);
            context.UserAddresses.Add(data);
            context.SaveChanges();
        }

        public List<UserAddressDto> GetAddress(int userId)
        {
            var address=context.UserAddresses.Where(p=> p.UserId == userId);
            var data =mapper.Map<List<UserAddressDto>>(address);
            return data;
        }
    }
}
