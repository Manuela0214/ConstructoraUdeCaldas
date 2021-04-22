using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.DbModel.ParametersModule
{
    public class ProjectDbModel
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

        private string proj_description;

        public string Proj_description
        {
            get { return proj_description; }
            set { proj_description = value; }
        }

        private string picture;

        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        private int cityId;

        public int CityId
        {
            get { return cityId; }
            set { cityId = value; }
        }

    }
}
