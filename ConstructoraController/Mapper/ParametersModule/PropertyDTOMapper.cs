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
    class PropertyDTOMapper : MapperBase<PropertyDbModel, PropertyDTO>
    {
        public override PropertyDTO MapperT1T2(PropertyDbModel input)
        {
            PropertyDTOMapper roleMapper = new PropertyDTOMapper();
            return new PropertyDTO()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Valor = input.Valor
            };
        }

        public override IEnumerable<PropertyDTO> MapperT1T2(IEnumerable<PropertyDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override PropertyDbModel MapperT2T1(PropertyDTO input)
        {
            return new PropertyDbModel()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Valor = input.Valor
            };
        }

        public override IEnumerable<PropertyDbModel> MapperT2T1(IEnumerable<PropertyDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}