using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora.Models.ParametersModule
{
    public class CountryModel
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

        private bool isSelectedByUser;

        public bool IsSelectedByUser
        {
            get { return isSelectedByUser; }
            set { isSelectedByUser = value; }
        }

        private IEnumerable<CityModel> cities;

        public IEnumerable<CityModel> Cities
        {
            get { return cities; }
            set { cities = value; }
        }
    }
}
