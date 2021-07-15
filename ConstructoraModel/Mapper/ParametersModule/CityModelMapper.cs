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
    class CityModelMapper : MapperBase<PARAM_CITY, CityDbModel>
    {
        private CountryImplModel model = new CountryImplModel();

        public override CityDbModel MapperT1T2(PARAM_CITY input)
        {
            var country = input.PARAM_COUNTRY;
            CountryModelMapper countryMapper = new CountryModelMapper();

            //IEnumerable<CountryDbModel> countries = model.RecordList("");

            return new CityDbModel
            {
                Id = input.ID,
                Code = input.CODE,
                Name = input.NAME,
                Country = countryMapper.MapperT1T2(country)
            };
        }

        public override IEnumerable<CityDbModel> MapperT1T2(IEnumerable<PARAM_CITY> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override PARAM_CITY MapperT2T1(CityDbModel input)
        {
            return new PARAM_CITY
            {
                ID = input.Id,
                CODE = input.Code,
                NAME = input.Name,
                COUNTRYID = input.CountryId
            };
        }

        public override IEnumerable<PARAM_CITY> MapperT2T1(IEnumerable<CityDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
