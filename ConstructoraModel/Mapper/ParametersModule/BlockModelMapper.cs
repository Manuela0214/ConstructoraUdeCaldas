using ConstructoraModel.DbModel.ParametersModule;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.Mapper.ParametersModule
{
    class BlockModelMapper : MapperBase<PARAM_BLOCK, BlockDbModel>
    {
        public override BlockDbModel MapperT1T2(PARAM_BLOCK input)
        {

            return new BlockDbModel()
            {
                Id = input.ID,
                Code = input.CODE,
                Name = input.NAME,
                Description = input.DESCRIPTION
            };
        }

        public override IEnumerable<BlockDbModel> MapperT1T2(IEnumerable<PARAM_BLOCK> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override PARAM_BLOCK MapperT2T1(BlockDbModel input)
        {
            return new PARAM_BLOCK()
            {
                ID = input.Id,
                CODE = input.Code,
                NAME = input.Name,
                DESCRIPTION = input.Description

            };
        }

        public override IEnumerable<PARAM_BLOCK> MapperT2T1(IEnumerable<BlockDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
