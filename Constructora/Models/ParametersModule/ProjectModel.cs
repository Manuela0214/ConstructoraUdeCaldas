using System;
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


        private string description;

        [DisplayName("Descripción")]
        [MaxLength(200, ErrorMessage = "El campo {0} puede tener una longitud máxima de {1} caracteres")]
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



        private int blockId;

        public int BlockId
        {
            get { return blockId; }
            set { blockId = value; }
        }


    }
}