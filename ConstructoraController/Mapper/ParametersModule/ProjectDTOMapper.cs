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
    class ProjectDTOMapper : MapperBase<ProjectDbModel, ProjectDTO>
    {
        private CityImplController modelCity = new CityImplController();

        public override ProjectDTO MapperT1T2(ProjectDbModel input)
        {
            CityDTOMapper cityMapper = new CityDTOMapper();

            return new ProjectDTO
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                Picture = input.Picture,
                City = cityMapper.MapperT1T2(input.City)
            };
        }

        public override IEnumerable<ProjectDTO> MapperT1T2(IEnumerable<ProjectDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override ProjectDbModel MapperT2T1(ProjectDTO input)
        {
            return new ProjectDbModel
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                Picture = input.Picture,
                CityId = input.CityId
            };
        }

        public override IEnumerable<ProjectDbModel> MapperT2T1(IEnumerable<ProjectDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}