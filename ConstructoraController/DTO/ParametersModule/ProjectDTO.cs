using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraController.DTO.ParametersModule
{
    public class ProjectDTO : DTOBase
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

        private string picture;

        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        private CityDTO city;

        public CityDTO City
        {
            get { return city; }
            set { city = value; }
        }

        private int cityId;

        public int CityId
        {
            get { return cityId; }
            set { cityId = value; }
        }

        private IEnumerable<CityDTO> cityList;

        public IEnumerable<CityDTO> CityList
        {
            get { return cityList; }
            set { cityList = value; }
        }




    }
}
