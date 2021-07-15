using Constructora.Models.ParametersModule;
using ConstructoraController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora.Mapper.ParametersModule
{
    class CityModelMapper : MapperBase<CityDTO, CityModel>
    {
        public override CityModel MapperT1T2(CityDTO input)
        {
            CountryModelMapper countryMapper = new CountryModelMapper();
            return new CityModel
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Country = countryMapper.MapperT1T2(input.Country)
            };
        }

        public override IEnumerable<CityModel> MapperT1T2(IEnumerable<CityDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override CityDTO MapperT2T1(CityModel input)
        {
            return new CityDTO
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                CountryId = input.CountryId

            };
        }

        public override IEnumerable<CityDTO> MapperT2T1(IEnumerable<CityModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
