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
    
    public partial class PARAM_FINANCIAL
    {
        public PARAM_FINANCIAL()
        {
            this.PARAM_CUSTOMER = new HashSet<PARAM_CUSTOMER>();
        }
    
        public int ID { get; set; }
        public string NAMEJOB { get; set; }
        public string PHONEJOB { get; set; }
        public int TOTALINCOME { get; set; }
        public System.DateTime TIMECURRENTWORK { get; set; }
        public string NAMEFAMILYREF { get; set; }
        public string CELLPHONEFAMILYREF { get; set; }
        public string NAMEPERSONALREF { get; set; }
        public string CELLPHONEPERSONALREF { get; set; }
    
        public virtual ICollection<PARAM_CUSTOMER> PARAM_CUSTOMER { get; set; }
    }
}