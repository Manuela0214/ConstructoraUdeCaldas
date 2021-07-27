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
    public class FinancialModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nameJob;
        [DisplayName("Nombre del trabajo")]
        public string NameJob
        {
            get { return nameJob; }
            set { nameJob = value; }
        }

        private string phoneJob;
        [DisplayName("Telefono laboral")]
        public string PhoneJob
        {
            get { return phoneJob; }
            set { phoneJob = value; }
        }

        private int totalInCome;
        [DisplayName("Total de ingresos")]
        public int TotalInCome
        {
            get { return totalInCome; }
            set { totalInCome = value; }
        }
        private DateTime timeCurrentJob;
        [DisplayName("Tiempo actual de trabajo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required()]


        public DateTime TimeCurrentJob
        {
            get { return timeCurrentJob; }
            set { timeCurrentJob = value; }
        }

        private string nameFamilyRef;
        [DisplayName("Nombre Referencia familiar")]
        public string NameFamilyRef
        {
            get { return nameFamilyRef; }
            set { nameFamilyRef = value; }
        }

        private string cellphoneFamilyRef;
        [DisplayName("Teléfono Referencia familiar")]
        public string CellphoneFamilyRef
        {
            get { return cellphoneFamilyRef; }
            set { cellphoneFamilyRef = value; }
        }

        private string namePersonalRef;
        [DisplayName("Nombre Referencia personal")]
        public string NamePersonalRef
        {
            get { return namePersonalRef; }
            set { namePersonalRef = value; }
        }

        private string cellphonePersonalRef;
        [DisplayName("Teléfono Referencia personal")]
        public string CellphonePersonalRef
        {
            get { return cellphonePersonalRef; }
            set { cellphonePersonalRef = value; }
        }

        private int customerId;

        [DisplayName("Cliente")]
        [Required()]
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }


        private CustomerModel customer;

        public CustomerModel Customer
        {
            get { return customer; }
            set { customer = value; }
        }


        private IEnumerable<CustomerModel> customerList;

        public IEnumerable<CustomerModel> CustomerList
        {
            get { return customerList; }
            set { customerList = value; }
        }
    }
}