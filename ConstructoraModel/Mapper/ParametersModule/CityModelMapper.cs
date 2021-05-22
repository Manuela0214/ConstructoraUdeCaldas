using ConstructoraModel.DbModel.ParametersModule;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.Mapper.ParametersModule
{
    class CityModelMapper : MapperBase<PARAM_CITY, CityDbModel>
    {
        public override CityDbModel MapperT1T2(PARAM_CITY input)
        {
            return new CityDbModel()
            {
                Id = input.ID,
                Code = input.CODE,
                Name = input.NAME
            };
        }

        public override IEnumerable<CityDbModel> MapperT1T2(IEnumerable<PARAM_CITY> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override PARAM_CITY MapperT2T1(CityDbModel input)
        {
            return new PARAM_CITY()
            {
                ID = input.Id,
                CODE = input.Code,
                NAME = input.Name
            };
        }

        public override IEnumerable<PARAM_CITY> MapperT2T1(IEnumerable<CityDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
