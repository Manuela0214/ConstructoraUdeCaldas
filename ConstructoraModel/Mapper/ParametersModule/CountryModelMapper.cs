using ConstructoraModel.DbModel.ParametersModule;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.Mapper.ParametersModule
{
    class CountryModelMapper : MapperBase<PARAM_COUNTRY, CountryDbModel>
    {
        public override CountryDbModel MapperT1T2(PARAM_COUNTRY input)
        {

            return new CountryDbModel()
            {
                Id = input.ID,
                Code = input.CODE,
                Name = input.NAME
            };
        }

        public override IEnumerable<CountryDbModel> MapperT1T2(IEnumerable<PARAM_COUNTRY> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }
        
        /**internal object MapperT1T2(int COUNTRYID)
        {
            throw new NotImplementedException();
        }**/


        public override PARAM_COUNTRY MapperT2T1(CountryDbModel input)
        {
            return new PARAM_COUNTRY()
            {
                ID = input.Id,
                CODE = input.Code,
                NAME = input.Name

            };
        }

        public override IEnumerable<PARAM_COUNTRY> MapperT2T1(IEnumerable<CountryDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
