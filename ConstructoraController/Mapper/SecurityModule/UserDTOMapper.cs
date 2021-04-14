using ConstructoraController.DTO.SecurityModule;
using ConstructoraModel.DbModel.SecurityModule;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraController.Mapper.SecurityModule
{
    class UserDTOMapper : MapperBase<UserDbModel, UserDTO>
    {
        public override UserDTO MapperT1T2(UserDbModel input)
        {
            RoleDTOMapper roleMapper = new RoleDTOMapper();
            return new UserDTO()
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

        public override IEnumerable<UserDTO> MapperT1T2(IEnumerable<UserDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override UserDbModel MapperT2T1(UserDTO input)
        {
            return new UserDbModel()
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

        public override IEnumerable<UserDbModel> MapperT2T1(IEnumerable<UserDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
