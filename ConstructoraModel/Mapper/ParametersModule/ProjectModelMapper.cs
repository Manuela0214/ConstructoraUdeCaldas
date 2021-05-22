using ConstructoraModel.DbModel.ParametersModule;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.Mapper.ParametersModule
{
    class ProjectModelMapper : MapperBase<PARAM_PROJECT, ProjectDbModel>
    {
        public override ProjectDbModel MapperT1T2(PARAM_PROJECT input)
        {

            return new ProjectDbModel()
            {
                Id = input.ID,
                Code = input.CODE,
                Name = input.NAME,
                Description = input.DESCRIPTION,
                Picture = input.PICTURE
            };
        }

        public override IEnumerable<ProjectDbModel> MapperT1T2(IEnumerable<PARAM_PROJECT> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override PARAM_PROJECT MapperT2T1(ProjectDbModel input)
        {
            return new PARAM_PROJECT()
            {
                ID = input.Id,
                CODE = input.Code,
                NAME = input.Name,
                DESCRIPTION = input.Description,
                PICTURE = input.Picture

            };
        }

        public override IEnumerable<PARAM_PROJECT> MapperT2T1(IEnumerable<ProjectDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
