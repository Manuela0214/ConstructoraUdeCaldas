//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConstructoraModel.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SEC_FORM
    {
        public SEC_FORM()
        {
            this.SEC_FORMS_ROLE = new HashSet<SEC_FORMS_ROLE>();
        }
    
        public int ID { get; set; }
        public string NAME { get; set; }
        public string URL { get; set; }
    
        public virtual ICollection<SEC_FORMS_ROLE> SEC_FORMS_ROLE { get; set; }
    }
}
