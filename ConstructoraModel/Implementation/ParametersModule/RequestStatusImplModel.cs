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
    public class RequestStatusImplModel
    {

        public int RecordCreation(RequestStatusDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    ///verifica si el PAIS con el nombre ya existe en algun registro 
                    if (db.PARAM_REQUEST_STATUS.Where(x => x.ID.Equals(dbModel.Id)).Count() > 0)
                    {
                        return 3;
                    }

                    RequestStatusModelMapper mapper = new RequestStatusModelMapper();
                    PARAM_REQUEST_STATUS record = mapper.MapperT2T1(dbModel);
                    db.PARAM_REQUEST_STATUS.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int RecordUpdate(RequestStatusDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.PARAM_REQUEST_STATUS.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.NAME = dbModel.Name;
                    record.DESCRIPTION = dbModel.Description;

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

        public int RecordRemove(RequestStatusDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.PARAM_REQUEST_STATUS.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    //Este se utilizaría para eliminar totalmente de la DB.
                    db.PARAM_REQUEST_STATUS.Remove(record); 
                    
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public IEnumerable<RequestStatusDbModel> RecordList(String filter)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                var listaLambda = db.PARAM_REQUEST_STATUS.Where(x => x.NAME.ToUpper().Contains(filter)).ToList();
                RequestStatusModelMapper mapper = new RequestStatusModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        public RequestStatusDbModel RecordSearch(int id)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                var record = db.PARAM_REQUEST_STATUS.Where(x => x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    RequestStatusModelMapper mapper = new RequestStatusModelMapper();
                    var recordFinal = mapper.MapperT1T2(record);
                    return recordFinal;
                }
                return null;
            }
        }
    }
}
