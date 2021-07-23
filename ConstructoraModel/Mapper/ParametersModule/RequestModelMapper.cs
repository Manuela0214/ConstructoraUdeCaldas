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
    class RequestModelMapper : MapperBase<PARAM_REQUEST, RequestDbModel>
    {
        private CustomerImplModel model1 = new CustomerImplModel();
        private PropertyImplModel model2 = new PropertyImplModel();
        private RequestStatusImplModel model3 = new RequestStatusImplModel();
        public override RequestDbModel MapperT1T2(PARAM_REQUEST input)
        {
            var customer = input.PARAM_CUSTOMER;
            var property = input.PARAM_PROPERTY;
            var requestStatus = input.PARAM_REQUEST_STATUS;
            CustomerModelMapper customerMapper = new CustomerModelMapper();
            PropertyModelMapper propertyMapper = new PropertyModelMapper();
            RequestStatusModelMapper requestStatusMapper = new RequestStatusModelMapper();
            //IEnumerable<CustomerDbModel> countries = model.RecordList("");

            return new RequestDbModel
            {
                Id = input.ID,
                DeliveryDate = input.DELIVERYDATE,
                ApprovedDate = input.APPROVEDDATE,
                EconomicOffer = input.ECONOMICOFFER,
                Consignment = input.CONSIGNMENT,
                Customer = customerMapper.MapperT1T2(customer),
                Property = propertyMapper.MapperT1T2(property),
                RequestStatus = requestStatusMapper.MapperT1T2(requestStatus)

            };
        }

        public override IEnumerable<RequestDbModel> MapperT1T2(IEnumerable<PARAM_REQUEST> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override PARAM_REQUEST MapperT2T1(RequestDbModel input)
        {
            return new PARAM_REQUEST
            {
                ID = input.Id,
                DELIVERYDATE = input.DeliveryDate,
                APPROVEDDATE = input.ApprovedDate,
                ECONOMICOFFER = input.EconomicOffer,
                CONSIGNMENT = input.Consignment,
                CUSTOMERID = input.CustomerId,
                PROPERTYID = input.PropertyId,
                REQUEST_STATUSID = input.RequestStatusId
            };
        }

        public override IEnumerable<PARAM_REQUEST> MapperT2T1(IEnumerable<RequestDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
