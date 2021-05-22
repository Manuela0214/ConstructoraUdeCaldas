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
        /// <summary>
        /// Method to map the ProjectDTO object to ProjectModel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override ProjectModel MapperT1T2(ProjectDTO input)
        {
            return new ProjectModel()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                Picture = input.Picture
            };
        }

        public override IEnumerable<ProjectModel> MapperT1T2(IEnumerable<ProjectDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override ProjectDTO MapperT2T1(ProjectModel input)
        {
            return new ProjectDTO()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Description = input.Description,
                Picture = input.Picture
            };
        }

        public override IEnumerable<ProjectDTO> MapperT2T1(IEnumerable<ProjectModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
