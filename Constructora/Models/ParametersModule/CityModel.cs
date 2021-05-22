using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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



        private int projectId;

        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }




    }
}