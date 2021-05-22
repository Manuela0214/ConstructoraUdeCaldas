using ConstructoraController.DTO.ParametersModule;
using ConstructoraModel.DbModel.ParametersModule;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraController.Mapper.ParametersModule
{
    class CountryDTOMapper : MapperBase<CountryDbModel, CountryDTO>
    {
        public override CountryDTO MapperT1T2(CountryDbModel input)
        {
            CountryDTOMapper roleMapper = new CountryDTOMapper();
            return new CountryDTO()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name
            };
        }

        public override IEnumerable<CountryDTO> MapperT1T2(IEnumerable<CountryDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override CountryDbModel MapperT2T1(CountryDTO input)
        {
            return new CountryDbModel()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name
            };
        }

        public override IEnumerable<CountryDbModel> MapperT2T1(IEnumerable<CountryDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}