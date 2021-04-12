using ConstructoraModel.DbModel;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.Implementation
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

                    SEC_ROLE role = new SEC_ROLE()
                    {
                        NAME = dbModel.Name,
                        REMOVED = false
                    };
                    db.SEC_ROLE.Add(role);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
        }

        public int RecordUpdate(RoleDbModel dbModel)
        {
            return 1;
        }

        public int RecordRemove(RoleDbModel dbModel)
        {
            return 1;
        }

        public IEnumerable<RoleDbModel> RecordList(String filter)
        {
            return null;
        }
    }
}
