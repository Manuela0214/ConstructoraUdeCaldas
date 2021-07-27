﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Constructora.Models.ParametersModule
{
    public class ProjectModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string code;

        [DisplayName("Codigo")]
        [Required()]
        [MaxLength(50)]
        public string Code
        {
            get { return code; }
            set { code = value; }
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
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string picture;

        [DisplayName("Imagen")]
        [Required()]
        public string Picture
        {
            get { return picture; }
            set { picture = value; }
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