using ConstructoraModel.DbModel.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.Implementation.ParametersModule
{
    public class ProjectImplModel
    {
        public int RecordCreation(ProjectDbModel dbModel)
        {
            return 1;
        }

        public int RecordUpdate(ProjectDbModel dbModel)
        {
            return 1;
        }

        public int RecordRemove(ProjectDbModel dbModel)
        {
            return 1;
        }

        public IEnumerable<ProjectDbModel> RecordList(string filter)
        {
            return null;
        }
    }
}
