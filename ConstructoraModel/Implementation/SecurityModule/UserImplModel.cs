using ConstructoraModel.DbModel.SecurityModule;
using ConstructoraModel.Mapper.SecurityModule;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

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
                    record.DOCUMENT = dbModel.Document;
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
        /// <param name="dbModel">Representa un filtro</param>
        /// <returns>Lista con los usuarios</returns>

        public IEnumerable<UserDbModel> RecordList(String filter)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                
                var lista = from role in db.SEC_USER
                            where !role.REMOVED && role.NAME.ToUpper().Contains(filter.ToUpper())
                            select role;

                UserModelMapper mapper = new UserModelMapper();

                //El mapeo se puede realizar con cualquiera de los dos métodos.
                var listaFinal = mapper.MapperT1T2(lista);
               
                return listaFinal;
            }
        }

        /// <summary>
        /// Cambio de contraseña
        /// </summary>
        /// <param name="currentPassword">Representa la clave actual</param>
        /// <param name="newPassword">Representa la nueva contraseña</param>
        /// <param name="userId">Representa el Id del usuario</param>
        /// <param name="email">Representa el correo del usuario</param>
        /// <returns>1: Ok, 2: Excepción,3: No existe el usuario</returns>
        public int ChangePassword(string currentPassword, string newPassword, int userId, out string email)
        {
            email = string.Empty;
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var user = db.SEC_USER.Where(x => x.ID == userId && x.USER_PASSWORD.Equals(currentPassword)).FirstOrDefault();
                    if (user == null)
                    {
                        return 3;
                    }
                    user.USER_PASSWORD = newPassword;
                    db.SaveChanges();
                    email = user.EMAIL;
                    return 1;
                }
                catch
                {
                    return 2;
                }                
            }
        }

        /// <summary>
        /// Restablecer la contraseña
        /// </summary>
        /// <param name="email">Correo del usuario</param>
        /// <param name="newPassword">Nueva contraseña del usuario</param>
        /// <returns>1: Ok, 2: Excepción,3: No existe el usuario</returns>
        public int PasswordReset(string email, string newPassword)
        {
            using (ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                try
                {
                    var user = db.SEC_USER.Where(x => x.EMAIL.Equals(email)).FirstOrDefault();
                    if (user == null)
                    {
                        return 3;
                    }
                    user.USER_PASSWORD = newPassword;
                    db.SaveChanges();
                    email = user.EMAIL;
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        /// <summary>
        /// Inicio de sesión del usuario
        /// </summary>
        /// <param name="dbModel">Representa un objeto con informacion del usuario</param>
        /// <returns>null: Si no existe un login o si existe se retorna el mismo</returns>
        public UserDbModel Login(UserDbModel dbModel)
        {
            using(ConstructoraDBEntities db = new ConstructoraDBEntities())
            {
                var login = (from user in db.SEC_USER
                            where user.EMAIL.Equals(dbModel.Email.ToUpper()) && user.USER_PASSWORD.Equals(dbModel.Password)
                            select user).FirstOrDefault();

                if(login == null)
                {
                    return null;
                }

                var date = dbModel.CurrentDate;
                SEC_SESSION session = new SEC_SESSION()
                {
                    USERID = login.ID,
                    LOGIN_DATE = date ,
                    TOKEN_STATUS = true,
                    TOKEN = this.GetToken(String.Concat(login.ID , date)),
                    IP_ADDRESS = this.GetIpAddress()
                };

                db.SEC_SESSION.Add(session);
                db.SaveChanges();
                UserModelMapper mapper = new UserModelMapper();
                return mapper.MapperT1T2(login);

            }
        }

        /// <summary>
        /// Obtención del token
        /// </summary>
        /// <param name="key">Representa la llave</param>
        /// <returns>Un código hash</returns>
        private string GetToken(string key)
        {
            int HashCode = key.GetHashCode();
            return HashCode.ToString();
        }

        /// <summary>
        /// Obtención de la dirección Ip
        /// </summary>
        /// <returns>Un string con la ip</returns>
        private string GetIpAddress()
        {
            string hostName = Dns.GetHostName();
            Console.WriteLine(hostName);
            //Get the IP
            string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            return myIP;
        } 

      

        
    }
}
