using Constructora.Models.ParametersModule;
using ConstructoraController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora.Mapper.ParametersModule
{
    class PaymentsModelMapper : MapperBase<PaymentsDTO, PaymentsModel>
    {
        public override PaymentsModel MapperT1T2(PaymentsDTO input)
        {
            RequestModelMapper requestMapper = new RequestModelMapper();
            return new PaymentsModel
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                Date = input.Date,
                Request = requestMapper.MapperT1T2(input.Request)
            };
        }

        public override IEnumerable<PaymentsModel> MapperT1T2(IEnumerable<PaymentsDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override PaymentsDTO MapperT2T1(PaymentsModel input)
        {
            return new PaymentsDTO
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description,
                Date = input.Date,
                RequestId = input.RequestId

            };
        }

        public override IEnumerable<PaymentsDTO> MapperT2T1(IEnumerable<PaymentsModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
