using ConstructoraModel.DbModel.ParametersModule;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.Mapper.ParametersModule
{
    class RequestStatusModelMapper : MapperBase<PARAM_REQUEST_STATUS, RequestStatusDbModel>
    {
        public override RequestStatusDbModel MapperT1T2(PARAM_REQUEST_STATUS input)
        {

            return new RequestStatusDbModel()
            {
                Id = input.ID,
                Name = input.NAME,
                Description = input.DESCRIPTION
            };
        }

        public override IEnumerable<RequestStatusDbModel> MapperT1T2(IEnumerable<PARAM_REQUEST_STATUS> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }
        
        /**internal object MapperT1T2(int REQUEST_STATUSID)
        {
            throw new NotImplementedException();
        }**/


        public override PARAM_REQUEST_STATUS MapperT2T1(RequestStatusDbModel input)
        {
            return new PARAM_REQUEST_STATUS()
            {
                ID = input.Id,
                NAME = input.Name,
                DESCRIPTION = input.Description

            };
        }

        public override IEnumerable<PARAM_REQUEST_STATUS> MapperT2T1(IEnumerable<RequestStatusDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
