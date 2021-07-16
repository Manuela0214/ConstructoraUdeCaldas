using Constructora.Models.ParametersModule;
using ConstructoraController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora.Mapper.ParametersModule
{
    class ProjectModelMapper : MapperBase<ProjectDTO, ProjectModel>
    {
        public override ProjectModel MapperT1T2(ProjectDTO input)
        {
            CityModelMapper cityMapper = new CityModelMapper();
            return new ProjectModel
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                Picture = input.Picture,
                City = cityMapper.MapperT1T2(input.City)
            };
        }

        public override IEnumerable<ProjectModel> MapperT1T2(IEnumerable<ProjectDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override ProjectDTO MapperT2T1(ProjectModel input)
        {
            return new ProjectDTO
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                Picture = input.Picture,
                CityId = input.CityId

            };
        }

        public override IEnumerable<ProjectDTO> MapperT2T1(IEnumerable<ProjectModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
