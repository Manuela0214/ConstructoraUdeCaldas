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
    public class PaymentsModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }



        private string name;

        [DisplayName("Nombre")]
        [Required()]
        [MaxLength(50)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;

        [DisplayName("Descripción")]
        [Required()]
        [MaxLength(50)]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private DateTime date;

        [DisplayName("Fecha")]
        [Required()]
        [MaxLength(50)]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private int requestId;

        [DisplayName("Solicitud")]
        [Required()]
        public int RequestId
        {
            get { return requestId; }
            set { requestId = value; }
        }


        private RequestModel request;

        public RequestModel Request
        {
            get { return request; }
            set { request = value; }
        }


        private IEnumerable<RequestModel> requestList;

        public IEnumerable<RequestModel> RequestList
        {
            get { return requestList; }
            set { requestList = value; }
        }
    }
}