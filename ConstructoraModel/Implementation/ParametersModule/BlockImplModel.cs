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
    public class BlockImplModel
    {

        public int RecordCreation(BlockDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    ///verifica si el proyecto con el nombre ya existe en algun registro 
                    if (db.PARAM_BLOCK.Where(x => x.ID.Equals(dbModel.Id)).Count() > 0)
                    {
                        return 3;
                    }

                    BlockModelMapper mapper = new BlockModelMapper();
                    PARAM_BLOCK record = mapper.MapperT2T1(dbModel);
                    db.PARAM_BLOCK.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int RecordUpdate(BlockDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.PARAM_BLOCK.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    record.CODE = dbModel.Code;
                    record.NAME = dbModel.Name;
                    record.DESCRIPTION = dbModel.Description;
                    //Aquí se debe tener una lista desplegable 
                    //record.PROPERTYID = dbModel.PropertyId;
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

        public int RecordRemove(BlockDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.PARAM_BLOCK.Where(x => x.ID == dbModel.Id).FirstOrDefault();
                    if (record == null)
                    {
                        return 3;
                    }
                    db.PARAM_BLOCK.Remove(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public IEnumerable<BlockDbModel> RecordList(String filter)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                var listaLambda = db.PARAM_BLOCK.Where(x => x.NAME.ToUpper().Contains(filter)).ToList();
                BlockModelMapper mapper = new BlockModelMapper();
                var listFinal = mapper.MapperT1T2(listaLambda);

                return listFinal.ToList();
            }
        }

        public BlockDbModel RecordSearch(int id)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                var record = db.PARAM_BLOCK.Where(x => x.ID == id).FirstOrDefault();
                if (record != null)
                {
                    BlockModelMapper mapper = new BlockModelMapper();
                    var recordFinal = mapper.MapperT1T2(record);
                    return recordFinal;
                }
                return null;
            }
        }
    }
}
