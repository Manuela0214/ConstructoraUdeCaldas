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
    class PropertyDTOMapper : MapperBase<PropertyDbModel, PropertyDTO>
    {
        private BlockImplController modelBlock = new BlockImplController();

        public override PropertyDTO MapperT1T2(PropertyDbModel input)
        {
            BlockDTOMapper blockMapper = new BlockDTOMapper();

            return new PropertyDTO
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Valor = input.Valor,
                Block = blockMapper.MapperT1T2(input.Block)
            };
        }

        public override IEnumerable<PropertyDTO> MapperT1T2(IEnumerable<PropertyDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override PropertyDbModel MapperT2T1(PropertyDTO input)
        {
            return new PropertyDbModel
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Valor = input.Valor,
                BlockId = input.BlockId
            };
        }

        public override IEnumerable<PropertyDbModel> MapperT2T1(IEnumerable<PropertyDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}