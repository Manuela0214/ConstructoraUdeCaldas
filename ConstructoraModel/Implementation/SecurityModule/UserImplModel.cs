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
    public class UserImplModel
    {
        /// <summary>
        /// Se agrega un nuevo registro de usuario
        /// </summary>
        /// <param name="dbModel">Representa un objeto con informacion del usuario</param>
        /// <returns>entero con la respuesta 1.OK 2.KO </returns>
        public int RecordCreation(UserDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    UserModelMapper mapper = new UserModelMapper();
                    SEC_USER record = mapper.MapperT2T1(dbModel);

                    record.CREATE_DATE = dbModel.CurrentDate;
                    record.CREATE_USER_ID = dbModel.UserInSessionId;
                   
                    db.SEC_USER.Add(record);
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
        /// Se actualiza un registro de un usuario
        /// </summary>
        /// <param name="dbModel">Representa un objeto con informacion del usuario</param>
        /// <returns>entero con la respuesta 1.OK 2.KO 3.Ya existe</returns>

        public int RecordUpdate(UserDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.SEC_USER.Where(x => x.ID == dbModel.Id).FirstOrDefault();

                    //verifica si existe un usuario
                    if (record == null)
                    {
                        return 3;
                    }

                    record.NAME = dbModel.Name;
                    record.LASTNAME = dbModel.Lastname;
                    record.CELLPHONE = dbModel.Cellphone;
                    record.EMAIL = dbModel.Email;
                    record.USER_PASSWORD = dbModel.Password;
                    record.UPDATE_USER_ID = dbModel.UserInSessionId;
                    record.UPDATE_DATE = dbModel.CurrentDate;
                
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
        /// Se elimina un registro de un usuario en la interfaz gráfica.
        /// </summary>
        /// <param name="dbModel">Representa un objeto con informacion del usuario</param>
        /// <returns>entero con la respuesta 1.OK 2.KO 3.Ya existe</returns>

        public int RecordRemove(UserDbModel dbModel)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var record = db.SEC_USER.Where(x => x.ID == dbModel.Id).FirstOrDefault();

                    //verifica si existe un usuario
                    if (record == null)
                    {
                        return 3;
                    }

                    //Este se utilizaría para eliminar totalmente de la DB.
                    //db.SEC_USER.Remove(record); 

                    //Aquí se elimina de la interfaz gráfica, pero queda el historial.
                    record.REMOVED = true;
                    record.REMOVE_USER_ID = dbModel.UserInSessionId;
                    record.REMOVE_DATE = dbModel.CurrentDate;

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
        /// Se listan basandose en un filtro los registros de los usuarios
        /// </summary>
        /// <param name="dbModel">Representa un objeto con informacion del usuario</param>
        /// <returns>Lista con los usuarios</returns>

        public IEnumerable<UserDbModel> RecordList(String filter)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                //Método Lambda
                var listaLambda = db.SEC_USER.Where(x => !x.REMOVED && x.NAME.ToUpper().Contains(filter.ToUpper())).ToList();
               
                //Método por Linq, similar a consultas SQL
                var listaLinq = from role in db.SEC_USER
                                where !role.REMOVED && role.NAME.ToUpper().Contains(filter.ToUpper())
                                select role;

                UserModelMapper mapper = new UserModelMapper();

                //El mapeo se puede realizar con cualquiera de los dos métodos.
                var listaFinal = mapper.MapperT1T2(listaLambda);
               
                return listaFinal;
            }
        }

        
    }
}
