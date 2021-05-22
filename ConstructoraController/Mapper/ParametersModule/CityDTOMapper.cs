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
    class CityDTOMapper : MapperBase<CityDbModel, CityDTO>
    {
        public override CityDTO MapperT1T2(CityDbModel input)
        {
            CityDTOMapper roleMapper = new CityDTOMapper();
            return new CityDTO()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name
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
                Name = input.Name
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