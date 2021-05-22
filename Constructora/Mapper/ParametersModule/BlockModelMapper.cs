using Constructora.Models.ParametersModule;
using ConstructoraController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora.Mapper.ParametersModule
{
    class BlockModelMapper : MapperBase<BlockDTO, BlockModel>
    {
        /// <summary>
        /// Method to map the BlockDTO object to BlockModel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override BlockModel MapperT1T2(BlockDTO input)
        {
            return new BlockModel()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description
            };
        }

        public override IEnumerable<BlockModel> MapperT1T2(IEnumerable<BlockDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override BlockDTO MapperT2T1(BlockModel input)
        {
            return new BlockDTO()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description
            };
        }

        public override IEnumerable<BlockDTO> MapperT2T1(IEnumerable<BlockModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
