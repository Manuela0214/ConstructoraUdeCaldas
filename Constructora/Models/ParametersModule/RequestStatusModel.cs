using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Constructora.Models.ParametersModule
{
    public class RequestStatusModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        [DisplayName("Nombre")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        [DisplayName("Descripción")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

    }
}