using ConstructoraController.DTO.ParametersModule;
using ConstructoraController.Implementation.ParametersModule;
using ConstructoraModel.DbModel.ParametersModule;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraController.Mapper.ParametersModule
{
    class CustomerDTOMapper : MapperBase<CustomerDbModel, CustomerDTO>
    {
        private CityImplController modelCity = new CityImplController();

        public override CustomerDTO MapperT1T2(CustomerDbModel input)
        {
            CityDTOMapper cityMapper = new CityDTOMapper();

            return new CustomerDTO
            {
                Id = input.Id,
                Document = input.Document,
                Name = input.Name,
                LastName = input.LastName,
                DateBirth = input.DateBirth,
                Picture = input.Picture,
                Cellphone = input.Cellphone,
                Email = input.Email,
                Address = input.Address,
                City = cityMapper.MapperT1T2(input.City)
            };
        }

        public override IEnumerable<CustomerDTO> MapperT1T2(IEnumerable<CustomerDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override CustomerDbModel MapperT2T1(CustomerDTO input)
        {
            return new CustomerDbModel
            {
                Id = input.Id,
                Document = input.Document,
                Name = input.Name,
                LastName = input.LastName,
                DateBirth = input.DateBirth,
                Picture = input.Picture,
                Cellphone = input.Cellphone,
                Email = input.Email,
                Address = input.Address,
                CityId = input.CityId
            };
        }

        public override IEnumerable<CustomerDbModel> MapperT2T1(IEnumerable<CustomerDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}