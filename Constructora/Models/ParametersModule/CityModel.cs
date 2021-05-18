using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora.Models.ParametersModule
{
    public class CityModel
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

        private int countryId;

        public int CountryId
        {
            get { return countryId; }
            set { countryId = value; }
        }

        private IEnumerable<ProjectModel> projects;

        public IEnumerable<ProjectModel> Projects
        {
            get { return projects; }
            set { projects = value; }
        }

        private bool isSelectedByUser;

        public bool IsSelectedByUser
        {
            get { return isSelectedByUser; }
            set { isSelectedByUser = value; }
        }

    }
}
