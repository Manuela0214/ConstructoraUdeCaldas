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
    public class CustomerImplModel
    {

        public int RecordCreation(CustomerDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    ///verifica si el cliente con el nombre ya existe en algun registro 
                    if (db.PARAM_CUSTOMER.Where(x => x.ID.Equals(dbModel.Id)).Count() > 0)
                    {
                        return 3;
                    }

                    CustomerModelMapper mapper = new CustomerModelMapper();
                    PARAM_CUSTOMER record = mapper.MapperT2T1(dbModel);
                    db.PARAM_CUSTOMER.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int RecordUpdate(CustomerDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.PARAM_CUSTOMER.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.DOCUMENT = dbModel.Document;
                    record.NAME = dbModel.Name;
                    record.LASTNAME = dbModel.LastName;
                    record.DATEBIRTH = dbModel.DateBirth;
                    record.PICTURE = dbModel.Picture;
                    record.CELLPHONE = dbModel.Cellphone;
                    record.EMAIL = dbModel.Email;
                    record.ADDRESS = dbModel.Address;
                    record.CITYID = dbModel.CityId;
                    record.FINANCIALID = dbModel.FinancialId;

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

        public int RecordRemove(CustomerDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.PARAM_CUSTOMER.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    db.PARAM_CUSTOMER.Remove(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public IEnumerable<CustomerDbModel> RecordList(String filter)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                var listaLambda = db.PARAM_CUSTOMER.Where(x => x.NAME.ToUpper().Contains(filter)).ToList();
                CustomerModelMapper mapper = new CustomerModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        public CustomerDbModel RecordSearch(int id)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                var record = db.PARAM_CUSTOMER.Where(x => x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    CustomerModelMapper mapper = new CustomerModelMapper();
                    var recordFinal = mapper.MapperT1T2(record);
                    return recordFinal;
                }
                return null;
            }
        }
    }
}
