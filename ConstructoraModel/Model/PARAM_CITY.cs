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
    
    public partial class PARAM_CITY
    {
        public PARAM_CITY()
        {
            this.PARAM_PROJECT = new HashSet<PARAM_PROJECT>();
            this.PARAM_CUSTOMER = new HashSet<PARAM_CUSTOMER>();
        }
    
        public int ID { get; set; }
        public string CODE { get; set; }
        public string NAME { get; set; }
        public int COUNTRYID { get; set; }
    
        public virtual PARAM_COUNTRY PARAM_COUNTRY { get; set; }
        public virtual ICollection<PARAM_PROJECT> PARAM_PROJECT { get; set; }
        public virtual ICollection<PARAM_CUSTOMER> PARAM_CUSTOMER { get; set; }
    }
}
