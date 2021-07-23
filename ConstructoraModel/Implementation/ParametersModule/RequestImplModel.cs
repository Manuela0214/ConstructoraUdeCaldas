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
    public class RequestImplModel
    {

        public int RecordCreation(RequestDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    ///verifica si el solicitud con el nombre ya existe en algun registro 
                    if (db.PARAM_REQUEST.Where(x => x.ID.Equals(dbModel.Id)).Count() > 0)
                    {
                        return 3;
                    }

                    RequestModelMapper mapper = new RequestModelMapper();
                    PARAM_REQUEST record = mapper.MapperT2T1(dbModel);
                    db.PARAM_REQUEST.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int RecordUpdate(RequestDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.PARAM_REQUEST.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.DELIVERYDATE = dbModel.DeliveryDate;
                    //record.APPROVEDDATE = dbModel.ApprovedDate;
                    record.ECONOMICOFFER = dbModel.EconomicOffer;
                    //record.CONSIGNMENT = dbModel.Consignment;
                    record.CUSTOMERID = dbModel.CustomerId;
                    record.PROPERTYID = dbModel.PropertyId;
                    record.REQUEST_STATUSID = dbModel.RequestStatusId;

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

        public int RecordRemove(RequestDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.PARAM_REQUEST.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    db.PARAM_REQUEST.Remove(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public IEnumerable<RequestDbModel> RecordList(String filter)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                var listaLambda = db.PARAM_REQUEST.Where(x => x.ID.ToString().Contains(filter)).ToList();
                RequestModelMapper mapper = new RequestModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        public RequestDbModel RecordSearch(int id)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                var record = db.PARAM_REQUEST.Where(x => x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    RequestModelMapper mapper = new RequestModelMapper();
                    var recordFinal = mapper.MapperT1T2(record);
                    return recordFinal;
                }
                return null;
            }
        }
    }
}
