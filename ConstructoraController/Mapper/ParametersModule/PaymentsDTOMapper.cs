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
    class PaymentsDTOMapper : MapperBase<PaymentsDbModel, PaymentsDTO>
    {
        private RequestImplController modelRequest = new RequestImplController();

        public override PaymentsDTO MapperT1T2(PaymentsDbModel input)
        {
            RequestDTOMapper requestMapper = new RequestDTOMapper();

            return new PaymentsDTO
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                Date = input.Date,
                Request = requestMapper.MapperT1T2(input.Request)
            };
        }

        public override IEnumerable<PaymentsDTO> MapperT1T2(IEnumerable<PaymentsDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override PaymentsDbModel MapperT2T1(PaymentsDTO input)
        {
            return new PaymentsDbModel
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                Date = input.Date,
                RequestId = input.RequestId
            };
        }

        public override IEnumerable<PaymentsDbModel> MapperT2T1(IEnumerable<PaymentsDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}