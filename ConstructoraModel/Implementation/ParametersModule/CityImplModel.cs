using ConstructoraModel.DbModel.ParametersModule;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.Implementation.ParametersModule
{
    public class CityImplModel
    {
        /// <summary>
        /// Se agrega un nuevo registro de usuario
        /// </summary>
        /// <param name="dbModel">Representa un objeto con informacion del usuario</param>
        /// <returns>entero con la respuesta 1.OK 2.KO </returns>
        public int RecordCreation(CityDbModel dbModel)
        {
            return 1;
        }

        public int RecordUpdate(CityDbModel dbModel)
        {
            return 1;
        }

        public int RecordRemove(CityDbModel dbModel)
        {
            return 1;
        }

        public IEnumerable<CityDbModel> RecordList(string filter)
        {
            return null;
        }
    }
}
