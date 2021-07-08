using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Constructora.Models.ParametersModule
{
    public class CityModel
    {
        private int id;
        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string code;
        [DisplayName("Código")]
        [Required()]

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string name;

        [DisplayName("Nombre")]
        [Required()]
        [MaxLength(100, ErrorMessage = "El campo {0} puede tener una longitud máxima de {1} caracteres")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int countryId;

        [DisplayName("Pais")]
        [Required()]
        public int CountryId
        {
            get { return countryId; }
            set { countryId = value; }
        }

        private CountryModel country;
        public CountryModel Country
        {
            get { return country; }
            set { country = value; }
        }


        private bool removed;
        [DisplayName("Eliminado")]
        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
        }

        private IEnumerable<CountryModel> countryList;

        public IEnumerable<CountryModel> CountryList
        {
            get { return countryList; }
            set { countryList = value; }
        }

         

    }
}