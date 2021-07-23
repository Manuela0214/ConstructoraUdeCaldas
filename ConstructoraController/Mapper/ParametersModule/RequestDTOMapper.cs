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
    class RequestDTOMapper : MapperBase<RequestDbModel, RequestDTO>
    {
        private CustomerImplController modelCustomer = new CustomerImplController();
        public override RequestDTO MapperT1T2(RequestDbModel input)
        {
            CustomerDTOMapper customerMapper = new CustomerDTOMapper();
            PropertyDTOMapper propertyMapper = new PropertyDTOMapper();
            RequestStatusDTOMapper requestStatusMapper = new RequestStatusDTOMapper();

            return new RequestDTO
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

        public override IEnumerable<RequestDTO> MapperT1T2(IEnumerable<RequestDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override RequestDbModel MapperT2T1(RequestDTO input)
        {
            return new RequestDbModel
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

        public override IEnumerable<RequestDbModel> MapperT2T1(IEnumerable<RequestDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}