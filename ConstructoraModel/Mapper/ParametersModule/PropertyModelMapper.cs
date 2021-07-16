using ConstructoraModel.DbModel.ParametersModule;
using ConstructoraModel.Implementation.ParametersModule;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.Mapper.ParametersModule
{
    class PropertyModelMapper : MapperBase<PARAM_PROPERTY, PropertyDbModel>
    {
        private BlockImplModel model = new BlockImplModel();

        public override PropertyDbModel MapperT1T2(PARAM_PROPERTY input)
        {
            var block = input.PARAM_BLOCK;
            BlockModelMapper blockMapper = new BlockModelMapper();

            //IEnumerable<BlockDbModel> countries = model.RecordList("");

            return new PropertyDbModel
            {
                Id = input.ID,
                Code = input.CODE,
                Name = input.NAME,
                Valor = input.VALOR,
                Block = blockMapper.MapperT1T2(block)
            };
        }

        public override IEnumerable<PropertyDbModel> MapperT1T2(IEnumerable<PARAM_PROPERTY> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override PARAM_PROPERTY MapperT2T1(PropertyDbModel input)
        {
            return new PARAM_PROPERTY
            {
                ID = input.Id,
                CODE = input.Code,
                NAME = input.Name,
                VALOR = input.Valor,
                BLOCKID = input.BlockId
            };
        }

        public override IEnumerable<PARAM_PROPERTY> MapperT2T1(IEnumerable<PropertyDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
