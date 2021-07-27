using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Constructora.Models.ParametersModule
{
    public class CustomerModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string document;

        [DisplayName("Documento")]
        [Required()]
        [MaxLength(50)]
        public string Document
        {
            get { return document; }
            set { document = value; }
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
        private string lastName;
        [DisplayName("Apellido")]
        [Required()]
        [MaxLength(50)]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private DateTime dateBirth;
        [DisplayName("Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyy-MM-dd}", ApplyFormatInEditMode =true)]
        [Required()]
        public DateTime DateBirth
        {
            get { return dateBirth; }
            set { dateBirth = value; }
        }

        private string picture;
        [DisplayName("Foto")]
        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        private string cellphone;
        [DisplayName("Teléfono")]
        [Required()]
        [MaxLength(13)]
        public string Cellphone
        {
            get { return cellphone; }
            set { cellphone = value; }
        }

        private string email;
        [DisplayName("Correo electrónico")]
        [Required()]
        [MaxLength(50)]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string address;
        [DisplayName("Dirección")]
        [Required()]
        [MaxLength(50)]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private int cityId;

        [DisplayName("Ciudad")]
        [Required()]
        public int CityId
        {
            get { return cityId; }
            set { cityId = value; }
        }


        private CityModel city;

        public CityModel City
        {
            get { return city; }
            set { city = value; }
        }


        private IEnumerable<CityModel> cityList;

        public IEnumerable<CityModel> CityList
        {
            get { return cityList; }
            set { cityList = value; }
        }

    }
}