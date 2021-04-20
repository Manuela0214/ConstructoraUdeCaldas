using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Constructora.Models.SecurityModule
{
    public class LoginModel
    {
        private string userName;
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener una longitud máxima de {1} caracteres")]

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string password;
        [MaxLength(50, ErrorMessage = "El campo {0} puede tener una longitud máxima de {1} caracteres")]

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

    }
}