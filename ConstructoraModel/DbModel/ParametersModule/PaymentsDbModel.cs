using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConstructoraModel.DbModel.ParametersModule
{
    public class PaymentsDbModel
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


        private RequestDbModel request;

        public RequestDbModel Request
        {
            get { return request; }
            set { request = value; }
        }

        private int requestId;

        public int RequestId
        {
            get { return requestId; }
            set { requestId = value; }
        }

        private IEnumerable<RequestDbModel> requestList;

        public IEnumerable<RequestDbModel> RequestList
        {
            get { return requestList; }
            set { requestList = value; }
        }



    }
}
