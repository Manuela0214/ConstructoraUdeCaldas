using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Constructora.Models.SecurityModule
{
    public class FormModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private bool isSelectedByUser;

        public bool IsSelectedByUser
        {
            get { return isSelectedByUser; }
            set { isSelectedByUser = value; }
        }

    }
}