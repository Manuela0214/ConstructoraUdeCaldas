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
    
    public partial class SEC_USER_ROLE
    {
        public int ID { get; set; }
        public int USERID { get; set; }
        public int ROLEID { get; set; }
    
        public virtual SEC_ROLE SEC_ROLE { get; set; }
        public virtual SEC_USER SEC_USER { get; set; }
    }
}
