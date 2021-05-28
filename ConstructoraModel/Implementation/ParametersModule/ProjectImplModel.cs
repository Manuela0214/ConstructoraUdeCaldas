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
    public class ProjectImplModel
    {

        public int RecordCreation(ProjectDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    ///verifica si el proyecto con el nombre ya existe en algun registro 
                    if (db.PARAM_PROJECT.Where(x => x.ID.Equals(dbModel.Id)).Count() > 0)
                    {
                        return 3;
                    }

                    ProjectModelMapper mapper = new ProjectModelMapper();
                    PARAM_PROJECT record = mapper.MapperT2T1(dbModel);
                    db.PARAM_PROJECT.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int RecordUpdate(ProjectDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.PARAM_PROJECT.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.CODE = dbModel.Code;
                    record.NAME = dbModel.Name;
                    record.DESCRIPTION = dbModel.Description;
                    record.PICTURE = dbModel.Picture;
                    //Aquí se debe tener una lista desplegable 
                    //record.BLOCKID = dbModel.BlockId;
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

        public int RecordRemove(ProjectDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.PARAM_PROJECT.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    db.PARAM_PROJECT.Remove(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public IEnumerable<ProjectDbModel> RecordList(String filter)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                var listaLambda = db.PARAM_PROJECT.Where(x => x.NAME.ToUpper().Contains(filter)).ToList();
                ProjectModelMapper mapper = new ProjectModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        public ProjectDbModel RecordSearch(int id)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                var record = db.PARAM_PROJECT.Where(x => x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    ProjectModelMapper mapper = new ProjectModelMapper();
                    var recordFinal = mapper.MapperT1T2(record);
                    return recordFinal;
                }
                return null;
            }
        }
    }
}
