﻿using Constructora.Models.SecurityModule;
using ConstructoraController.DTO.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora.Mapper.SecurityModule
{
    class UserModelMapper : MapperBase<UserDTO, UserModel>
    {
        public override UserModel MapperT1T2(UserDTO input)
        {
            RoleModelMapper roleMapper = new RoleModelMapper();
            return new UserModel()
            {
                Id = input.Id,
                Name = input.Name,
                Lastname = input.Lastname,
                Document = input.Document,
                Cellphone = input.Cellphone,
                Email = input.Email,
                Password = input.Password,
                Roles = roleMapper.MapperT1T2(input.Roles),
                Token = input.Token
            };
        }

        public override IEnumerable<UserModel> MapperT1T2(IEnumerable<UserDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override UserDTO MapperT2T1(UserModel input)
        {
            return new UserDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Lastname = input.Lastname,
                Document = input.Document,
                Cellphone = input.Cellphone,
                Email = input.Email,
                Password = input.Password
            };
        }

        public override IEnumerable<UserDTO> MapperT2T1(IEnumerable<UserModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
