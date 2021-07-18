using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.DbModel.ParametersModule
{
    public class CustomerDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string document;

        public string Document
        {
            get { return document; }
            set { document = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private DateTime dateBirth;

        public DateTime DateBirth
        {
            get { return dateBirth; }
            set { dateBirth = value; }
        }

        private string picture;

        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        private string cellphone;

        public string Cellphone
        {
            get { return cellphone; }
            set { cellphone = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        private CityDbModel city;

        public CityDbModel City
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

        private IEnumerable<CityDbModel> cityList;

        public IEnumerable<CityDbModel> CityList
        {
            get { return cityList; }
            set { cityList = value; }
        }



    }
}
