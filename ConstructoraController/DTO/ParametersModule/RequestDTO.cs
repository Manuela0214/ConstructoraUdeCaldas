using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConstructoraController.DTO.ParametersModule
{
    public class RequestDTO : DTOBase
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

        /**private DateTime approvedDate;

        public DateTime ApprovedDate
        {
            get { return approvedDate; }
            set { approvedDate = value; }
        }**/

        private int economicOffer;

        public int EconomicOffer
        {
            get { return economicOffer; }
            set { economicOffer = value; }
        }

        /**private int consignment;

        public int Consignment
        {
            get { return consignment; }
            set { consignment = value; }
        }**/


        //Customer

        private CustomerDTO customer;

        public CustomerDTO Customer
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

        private IEnumerable<CustomerDTO> customerList;

        public IEnumerable<CustomerDTO> CustomerList
        {
            get { return customerList; }
            set { customerList = value; }
        }
        //Property

        private PropertyDTO property;

        public PropertyDTO Property
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

        private IEnumerable<PropertyDTO> propertyList;

        public IEnumerable<PropertyDTO> PropertyList
        {
            get { return propertyList; }
            set { propertyList = value; }
        }
        //RequestStatus

        private RequestStatusDTO requestStatus;

        public RequestStatusDTO RequestStatus
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

        private IEnumerable<RequestStatusDTO> requestStatusList;

        public IEnumerable<RequestStatusDTO> RequestStatusList
        {
            get { return requestStatusList; }
            set { requestStatusList = value; }
        }

    }
}
