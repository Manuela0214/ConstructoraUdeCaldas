using ConstructoraModel.DbModel.SecurityModule;
using ConstructoraModel.Mapper.SecurityModule;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.Implementation.SecurityModule
{
    public class RoleImplModel
    {
        /// <summary>
        /// Se agrega un nuevo registro a los roles
        /// </summary>
        /// <param name="dbModel">Representa un objeto con informacion del rol</param>
        /// <returns>entero con la respuesta 1.OK 2.KO 3.Ya existe</returns>
        public int RecordCreation(RoleDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    //verifica si existe un rol con el nombre que se quiere crear el nuevo
                    if (db.SEC_ROLE.Where(x => x.NAME.ToUpper().Equals(dbModel.Name.ToUpper())).Count() > 0)
                    {
                        return 3;
                    }

                    RoleModelMapper mapper = new RoleModelMapper();
                    SEC_ROLE record = mapper.MapperT2T1(dbModel);
                    db.SEC_ROLE.Add(record);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        /// <summary>
        /// Se actualiza un registro de un rol
        /// </summary>
        /// <param name="dbModel">Representa un objeto con informacion del rol</param>
        /// <returns>entero con la respuesta 1.OK 2.KO 3.Ya existe</returns>

        public int RecordUpdate(RoleDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.SEC_ROLE.Where(x => x.ID == dbModel.Id).FirstOrDefault();

                    //verifica si existe un registro
                    if (record == null)
                    {
                        return 3;
                    }

                    record.NAME = dbModel.Name;
                    record.REMOVED = dbModel.Removed;

                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }


        /// <summary>
        /// Se elimina un registro de un rol en la interfaz gráfica.
        /// </summary>
        /// <param name="dbModel">Representa un objeto con informacion del rol</param>
        /// <returns>entero con la respuesta 1.OK 2.KO 3.Ya existe</returns>

        public int RecordRemove(RoleDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.SEC_ROLE.Where(x => x.ID == dbModel.Id).FirstOrDefault();

                    //verifica si existe un registro
                    if (record == null)
                    {
                        return 3;
                    }

                    //Este se utilizaría para eliminar totalmente de la DB.
                    //db.SEC_ROLE.Remove(record); 

                    //Aquí se elimina de la interfaz gráfica, pero queda el historial.
                    record.REMOVED = true;
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        /// <summary>
        /// Se listan basandose en un filtro los registros de los roles
        /// </summary>
        /// <param name="filter">Representa un objeto con informacion del rol</param>
        /// <returns>Lista con los roles, teniendo su id y su nombre respectivo.</returns>

        public IEnumerable<RoleDbModel> RecordList(String filter)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                //Método Lambda
                //var listaLambda = db.SEC_ROLE.Where(x => !x.REMOVED && x.NAME.ToUpper().Contains(filter.ToUpper())).ToList();
               
                //Método por Linq, similar a consultas SQL
                var listaLinq = from role in db.SEC_ROLE
                                where !role.REMOVED && role.NAME.ToUpper().Contains(filter)
                                select role;

                RoleModelMapper mapper = new RoleModelMapper();

                //El mapeo se puede realizar con cualquiera de los dos métodos.
                var listaFinal = mapper.MapperT1T2(listaLinq);
               
                return listaFinal.ToList();
            }
        }

        
    }
}
