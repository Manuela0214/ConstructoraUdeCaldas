using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.DbModel.ParametersModule
{
    public class FinancialDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nameJob;

        public string NameJob
        {
            get { return nameJob; }
            set { nameJob = value; }
        }

        private string phoneJob;

        public string PhoneJob
        {
            get { return phoneJob; }
            set { phoneJob = value; }
        }

        private int totalInCome;

        public int TotalInCome
        {
            get { return totalInCome; }
            set { totalInCome = value; }
        }

        private DateTime timeCurrentJob;

        public DateTime TimeCurrentJob
        {
            get { return timeCurrentJob; }
            set { timeCurrentJob = value; }
        }

        private string nameFamilyRef;

        public string NameFamilyRef
        {
            get { return nameFamilyRef; }
            set { nameFamilyRef = value; }
        }

        private string cellphoneFamilyRef;

        public string CellphoneFamilyRef
        {
            get { return cellphoneFamilyRef; }
            set { cellphoneFamilyRef = value; }
        }

        private string namePersonalRef;

        public string NamePersonalRef
        {
            get { return namePersonalRef; }
            set { namePersonalRef = value; }
        }

        private string cellphonePersonalRef;

        public string CellphonePersonalRef
        {
            get { return cellphonePersonalRef; }
            set { cellphonePersonalRef = value; }
        }

        
    }
}
