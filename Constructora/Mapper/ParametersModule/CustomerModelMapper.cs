using Constructora.Models.ParametersModule;
using ConstructoraController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora.Mapper.ParametersModule
{
    class CustomerModelMapper : MapperBase<CustomerDTO, CustomerModel>
    {
        public override CustomerModel MapperT1T2(CustomerDTO input)
        {
            CityModelMapper cityMapper = new CityModelMapper();
            FinancialModelMapper financialMapper = new FinancialModelMapper();
            return new CustomerModel
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
                City = cityMapper.MapperT1T2(input.City),
                Financial = financialMapper.MapperT1T2(input.Financial)
            };
        }

        public override IEnumerable<CustomerModel> MapperT1T2(IEnumerable<CustomerDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override CustomerDTO MapperT2T1(CustomerModel input)
        {
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
                CityId = input.CityId,
                FinancialId = input.FinancialId

            };
        }

        public override IEnumerable<CustomerDTO> MapperT2T1(IEnumerable<CustomerModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
