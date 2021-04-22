using ConstructoraModel.DbModel.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.Implementation.ParametersModule
{
    public class CountryImplModel
    {
        public int RecordCreation(CountryDbModel dbModel)
        {
            return 1;
        }

        public int RecordUpdate(CountryDbModel dbModel)
        {
            return 1;
        }

        public int RecordRemove(CountryDbModel dbModel)
        {
            return 1;
        }

        public IEnumerable<CountryDbModel> RecordList(string filter)
        {
            return null;
        }
    }
}
