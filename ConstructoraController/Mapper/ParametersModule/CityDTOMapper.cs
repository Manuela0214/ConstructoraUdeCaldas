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
    class CityDTOMapper : MapperBase<CityDbModel, CityDTO>
    {
        private CountryImplController modelCountry = new CountryImplController();
        public override CityDTO MapperT1T2(CityDbModel input)
        {
            CountryDTOMapper countryMapper = new CountryDTOMapper();
            return new CityDTO()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Country = countryMapper.MapperT1T2(input.Country)
            };
        }

        public override IEnumerable<CityDTO> MapperT1T2(IEnumerable<CityDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override CityDbModel MapperT2T1(CityDTO input)
        {
            return new CityDbModel()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                CountryId = input.CountryId
            };
        }

        public override IEnumerable<CityDbModel> MapperT2T1(IEnumerable<CityDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}