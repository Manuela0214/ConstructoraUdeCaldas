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
    class BlockDTOMapper : MapperBase<BlockDbModel, BlockDTO>
    {
        public override BlockDTO MapperT1T2(BlockDbModel input)
        {
            BlockDTOMapper roleMapper = new BlockDTOMapper();
            return new BlockDTO()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description
            };
        }

        public override IEnumerable<BlockDTO> MapperT1T2(IEnumerable<BlockDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override BlockDbModel MapperT2T1(BlockDTO input)
        {
            return new BlockDbModel()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description
            };
        }

        public override IEnumerable<BlockDbModel> MapperT2T1(IEnumerable<BlockDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}