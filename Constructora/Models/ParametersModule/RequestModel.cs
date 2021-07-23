using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Constructora.Models.ParametersModule
{
    public class RequestModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime deliveryDate;
        [DisplayName("Fecha de envío")]
        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }

        private DateTime approvedDate;
        [DisplayName("Fecha de aprobación")]
        public DateTime ApprovedDate
        {
            get { return approvedDate; }
            set { approvedDate = value; }
        }

        private int economicOffer;
        [DisplayName("Oferta económica")]
        public int EconomicOffer
        {
            get { return economicOffer; }
            set { economicOffer = value; }
        }


        private int consignment;
        [DisplayName("Consignación")]
        public int Consignment
        {
            get { return consignment; }
            set { consignment = value; }
        }


        //Customer
        private int customerId;

        [DisplayName("Cliente")]
        [Required()]
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }


        private CustomerModel customer;

        public CustomerModel Customer
        {
            get { return customer; }
            set { customer = value; }
        }


        private IEnumerable<CustomerModel> customerList;

        public IEnumerable<CustomerModel> CustomerList
        {
            get { return customerList; }
            set { customerList = value; }
        }


        //Property
        private int propertyId;

        [DisplayName("Propiedad")]
        [Required()]
        public int PropertyId
        {
            get { return propertyId; }
            set { propertyId = value; }
        }


        private PropertyModel property;

        public PropertyModel Property
        {
            get { return property; }
            set { property = value; }
        }


        private IEnumerable<PropertyModel> propertyList;

        public IEnumerable<PropertyModel> PropertyList
        {
            get { return propertyList; }
            set { propertyList = value; }
        }

        //RequestStatus
        private int requestStatusId;

        [DisplayName("Estado de Solicitud ")]
        [Required()]
        public int RequestStatusId
        {
            get { return requestStatusId; }
            set { requestStatusId = value; }
        }


        private RequestStatusModel requestStatus;

        public RequestStatusModel RequestStatus
        {
            get { return requestStatus; }
            set { requestStatus = value; }
        }


        private IEnumerable<RequestStatusModel> requestStatusList;

        public IEnumerable<RequestStatusModel> RequestStatusList
        {
            get { return requestStatusList; }
            set { requestStatusList = value; }
        }
    }
}