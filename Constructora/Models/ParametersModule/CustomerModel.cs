﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [Required()]
        public DateTime DateBirth
        {
            get { return dateBirth; }
            set { dateBirth = value; }
        }

        private string picture;
        [DisplayName("Imagen")]
        [Required()]
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

        private int financialId;

        [DisplayName("Información financiera")]
        [Required()]
        public int FinancialId
        {
            get { return financialId; }
            set { financialId = value; }
        }


        private FinancialModel financial;

        public FinancialModel Financial
        {
            get { return financial; }
            set { financial = value; }
        }


        private IEnumerable<FinancialModel> financialList;

        public IEnumerable<FinancialModel> FinancialList
        {
            get { return financialList; }
            set { financialList = value; }
        }
    }
}