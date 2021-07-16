using Constructora.Models.ParametersModule;
using ConstructoraController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora.Mapper.ParametersModule
{
    class PropertyModelMapper : MapperBase<PropertyDTO, PropertyModel>
    {
        public override PropertyModel MapperT1T2(PropertyDTO input)
        {
            BlockModelMapper blockMapper = new BlockModelMapper();
            return new PropertyModel
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Valor = input.Valor,
                Block = blockMapper.MapperT1T2(input.Block)
            };
        }

        public override IEnumerable<PropertyModel> MapperT1T2(IEnumerable<PropertyDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override PropertyDTO MapperT2T1(PropertyModel input)
        {
            return new PropertyDTO
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Valor = input.Valor,
                BlockId = input.BlockId

            };
        }

        public override IEnumerable<PropertyDTO> MapperT2T1(IEnumerable<PropertyModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
