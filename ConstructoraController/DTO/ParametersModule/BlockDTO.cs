using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraController.DTO.ParametersModule
{
    public class BlockDTO : DTOBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
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

        private int propertyId;

        public int PropertyId
        {
            get { return propertyId; }
            set { propertyId = value; }
        }




    }
}
