using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConstructoraController.DTO.ParametersModule
{
    public class PaymentsDTO : DTOBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }



        private int requestId;

        public int RequestId
        {
            get { return requestId; }
            set { requestId = value; }
        }

        private RequestDTO request;

        public RequestDTO Request
        {
            get { return request; }
            set { request = value; }
        }

        private IEnumerable<RequestDTO> requestList;

        public IEnumerable<RequestDTO> RequestList
        {
            get { return requestList; }
            set { requestList = value; }
        }

    }
}
