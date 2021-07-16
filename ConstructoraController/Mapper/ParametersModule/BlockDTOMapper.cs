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
    class BlockDTOMapper : MapperBase<BlockDbModel, BlockDTO>
    {
        private ProjectImplController modelProject = new ProjectImplController();

        public override BlockDTO MapperT1T2(BlockDbModel input)
        {
            ProjectDTOMapper projectMapper = new ProjectDTOMapper();

            return new BlockDTO
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                Project = projectMapper.MapperT1T2(input.Project)
            };
        }

        public override IEnumerable<BlockDTO> MapperT1T2(IEnumerable<BlockDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override BlockDbModel MapperT2T1(BlockDTO input)
        {
            return new BlockDbModel
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                ProjectId = input.ProjectId
            };
        }

        public override IEnumerable<BlockDbModel> MapperT2T1(IEnumerable<BlockDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}