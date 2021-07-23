using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConstructoraModel.DbModel.ParametersModule
{
    public class RequestDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime deliveryDate;

        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }

        private DateTime approvedDate;

        public DateTime ApprovedDate
        {
            get { return approvedDate; }
            set { approvedDate = value; }
        }

        private int economicOffer;

        public int EconomicOffer
        {
            get { return economicOffer; }
            set { economicOffer = value; }
        }

        private int consignment;

        public int Consignment
        {
            get { return consignment; }
            set { consignment = value; }
        }


        //Customer

        private CustomerDbModel customer;

        public CustomerDbModel Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private int customerId;

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        private IEnumerable<CustomerDbModel> customerList;

        public IEnumerable<CustomerDbModel> CustomerList
        {
            get { return customerList; }
            set { customerList = value; }
        }
        //Property

        private PropertyDbModel property;

        public PropertyDbModel Property
        {
            get { return property; }
            set { property = value; }
        }

        private int propertyId;

        public int PropertyId
        {
            get { return propertyId; }
            set { propertyId = value; }
        }

        private IEnumerable<PropertyDbModel> propertyList;

        public IEnumerable<PropertyDbModel> PropertyList
        {
            get { return propertyList; }
            set { propertyList = value; }
        }
        //RequestStatus

        private RequestStatusDbModel requestStatus;

        public RequestStatusDbModel RequestStatus
        {
            get { return requestStatus; }
            set { requestStatus = value; }
        }

        private int requestStatusId;

        public int RequestStatusId
        {
            get { return requestStatusId; }
            set { requestStatusId = value; }
        }

        private IEnumerable<RequestStatusDbModel> requestStatusList;

        public IEnumerable<RequestStatusDbModel> RequestStatusList
        {
            get { return requestStatusList; }
            set { requestStatusList = value; }
        }



    }
}
