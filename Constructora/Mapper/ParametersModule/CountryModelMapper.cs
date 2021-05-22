using Constructora.Models.ParametersModule;
using ConstructoraController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora.Mapper.ParametersModule
{
    class CountryModelMapper : MapperBase<CountryDTO, CountryModel>
    {
        /// <summary>
        /// Method to map the CountryDTO object to CountryModel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override CountryModel MapperT1T2(CountryDTO input)
        {
            return new CountryModel()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name
            };
        }

        public override IEnumerable<CountryModel> MapperT1T2(IEnumerable<CountryDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override CountryDTO MapperT2T1(CountryModel input)
        {
            return new CountryDTO()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name
            };
        }

        public override IEnumerable<CountryDTO> MapperT2T1(IEnumerable<CountryModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
