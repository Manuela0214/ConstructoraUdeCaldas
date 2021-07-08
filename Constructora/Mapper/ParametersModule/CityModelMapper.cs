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
        /// <summary>
        /// Method to map the CityDTO object to CityModel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override CityModel MapperT1T2(CityDTO input)
        {
            CountryModelMapper countryMapper = new CountryModelMapper();
            return new CityModel()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Country = countryMapper.MapperT1T2(input.Country)
            };
        }

        public override IEnumerable<CityModel> MapperT1T2(IEnumerable<CityDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override CityDTO MapperT2T1(CityModel input)
        {
            return new CityDTO()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                CountryId = input.CountryId
            };
        }

        public override IEnumerable<CityDTO> MapperT2T1(IEnumerable<CityModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
