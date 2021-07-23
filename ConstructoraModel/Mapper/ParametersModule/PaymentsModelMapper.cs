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
    class PaymentsModelMapper : MapperBase<PARAM_PAYMENTS, PaymentsDbModel>
    {
        private RequestImplModel model = new RequestImplModel();

        public override PaymentsDbModel MapperT1T2(PARAM_PAYMENTS input)
        {
            var request = input.PARAM_REQUEST;
            RequestModelMapper requestMapper = new RequestModelMapper();

            //IEnumerable<RequestDbModel> countries = model.RecordList("");

            return new PaymentsDbModel
            {
                Id = input.ID,
                Name = input.NAME,
                Description = input.DESCRIPTION,
                Date = input.DATE,
                Request = requestMapper.MapperT1T2(request)
            };
        }

        public override IEnumerable<PaymentsDbModel> MapperT1T2(IEnumerable<PARAM_PAYMENTS> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override PARAM_PAYMENTS MapperT2T1(PaymentsDbModel input)
        {
            return new PARAM_PAYMENTS
            {
                ID = input.Id,
                NAME = input.Name,
                DESCRIPTION = input.Description,
                DATE= input.Date,
                REQUESTID = input.RequestId
            };
        }

        public override IEnumerable<PARAM_PAYMENTS> MapperT2T1(IEnumerable<PaymentsDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
