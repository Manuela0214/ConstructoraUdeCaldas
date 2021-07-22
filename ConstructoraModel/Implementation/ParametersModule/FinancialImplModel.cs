using ConstructoraModel.DbModel.ParametersModule;
using ConstructoraModel.Mapper.ParametersModule;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.Implementation.ParametersModule
{
    public class FinancialImplModel
    {

        public int RecordCreation(FinancialDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    ///verifica si el PAIS con el nombre ya existe en algun registro 
                    if (db.PARAM_FINANCIAL.Where(x => x.ID.Equals(dbModel.Id)).Count() > 0)
                    {
                        return 3;
                    }

                    FinancialModelMapper mapper = new FinancialModelMapper();
                    PARAM_FINANCIAL record = mapper.MapperT2T1(dbModel);
                    db.PARAM_FINANCIAL.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int RecordUpdate(FinancialDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.PARAM_FINANCIAL.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.NAMEJOB = dbModel.NameJob;
                    record.PHONEJOB = dbModel.PhoneJob;
                    record.TOTALINCOME = dbModel.TotalInCome;
                    record.TIMECURRENTJOB = dbModel.TimeCurrentJob;
                    record.NAMEFAMILYREF = dbModel.NameFamilyRef;
                    record.CELLPHONEFAMILYREF = dbModel.CellphoneFamilyRef; ;
                    record.NAMEPERSONALREF = dbModel.NamePersonalRef;
                    record.CELLPHONEPERSONALREF = dbModel.CellphonePersonalRef;
                    record.CUSTOMERID = dbModel.CustomerId;

                    db.Entry(record).State = EntityState.Modified;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int RecordRemove(FinancialDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.PARAM_FINANCIAL.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    db.PARAM_FINANCIAL.Remove(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public IEnumerable<FinancialDbModel> RecordList(String filter)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                var listaLambda = db.PARAM_FINANCIAL.Where(x => x.NAMEFAMILYREF.ToUpper().Contains(filter)).ToList();
                FinancialModelMapper mapper = new FinancialModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        public FinancialDbModel RecordSearch(int id)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                var record = db.PARAM_FINANCIAL.Where(x => x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    FinancialModelMapper mapper = new FinancialModelMapper();
                    var recordFinal = mapper.MapperT1T2(record);
                    return recordFinal;
                }
                return null;
            }
        }
    }
}
