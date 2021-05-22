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
    class ProjectDTOMapper : MapperBase<ProjectDbModel, ProjectDTO>
    {
        public override ProjectDTO MapperT1T2(ProjectDbModel input)
        {
            ProjectDTOMapper roleMapper = new ProjectDTOMapper();
            return new ProjectDTO()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                Picture = input.Picture
            };
        }

        public override IEnumerable<ProjectDTO> MapperT1T2(IEnumerable<ProjectDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override ProjectDbModel MapperT2T1(ProjectDTO input)
        {
            return new ProjectDbModel()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                Picture = input.Picture
            };
        }

        public override IEnumerable<ProjectDbModel> MapperT2T1(IEnumerable<ProjectDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}