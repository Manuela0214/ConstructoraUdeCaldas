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
    class BlockModelMapper : MapperBase<PARAM_BLOCK, BlockDbModel>
    {
        private ProjectImplModel model = new ProjectImplModel();

        public override BlockDbModel MapperT1T2(PARAM_BLOCK input)
        {
            var project = input.PARAM_PROJECT;
            ProjectModelMapper projectMapper = new ProjectModelMapper();

            //IEnumerable<ProjectDbModel> countries = model.RecordList("");

            return new BlockDbModel
            {
                Id = input.ID,
                Code = input.CODE,
                Name = input.NAME,
                Description = input.DESCRIPTION,
                Project = projectMapper.MapperT1T2(project)
            };
        }

        public override IEnumerable<BlockDbModel> MapperT1T2(IEnumerable<PARAM_BLOCK> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override PARAM_BLOCK MapperT2T1(BlockDbModel input)
        {
            return new PARAM_BLOCK
            {
                ID = input.Id,
                CODE = input.Code,
                NAME = input.Name,
                DESCRIPTION = input.Description,
                PROJECTID = input.ProjectId
            };
        }

        public override IEnumerable<PARAM_BLOCK> MapperT2T1(IEnumerable<BlockDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
