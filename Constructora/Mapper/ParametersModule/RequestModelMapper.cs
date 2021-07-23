using Constructora.Models.ParametersModule;
using ConstructoraController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora.Mapper.ParametersModule
{
    class RequestModelMapper : MapperBase<RequestDTO, RequestModel>
    {
        public override RequestModel MapperT1T2(RequestDTO input)
        {
            CustomerModelMapper customerMapper = new CustomerModelMapper();
            PropertyModelMapper propertyMapper = new PropertyModelMapper();
            RequestStatusModelMapper requestStatusMapper = new RequestStatusModelMapper();

            return new RequestModel
            {
                Id = input.Id,
                DeliveryDate = input.DeliveryDate,
                ApprovedDate = input.ApprovedDate,
                EconomicOffer = input.EconomicOffer,
                Consignment = input.Consignment,
                Customer = customerMapper.MapperT1T2(input.Customer),
                Property = propertyMapper.MapperT1T2(input.Property),
                RequestStatus = requestStatusMapper.MapperT1T2(input.RequestStatus)
            };
        }

        public override IEnumerable<RequestModel> MapperT1T2(IEnumerable<RequestDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override RequestDTO MapperT2T1(RequestModel input)
        {
            return new RequestDTO
            {
                Id = input.Id,
                DeliveryDate = input.DeliveryDate,
                ApprovedDate = input.ApprovedDate,
                EconomicOffer = input.EconomicOffer,
                Consignment = input.Consignment,
                CustomerId = input.CustomerId,
                PropertyId = input.PropertyId,
                RequestStatusId = input.RequestStatusId

            };
        }

        public override IEnumerable<RequestDTO> MapperT2T1(IEnumerable<RequestModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
