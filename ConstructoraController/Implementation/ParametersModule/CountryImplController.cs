using ConstructoraController.DTO.ParametersModule;
using ConstructoraController.Mapper.ParametersModule;
using ConstructoraController.Services;
using ConstructoraModel.DbModel.ParametersModule;
using ConstructoraModel.Implementation.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraController.Implementation.ParametersModule
{
    public class CountryImplController
    {
        private CountryImplModel model;

        public CountryImplController()
        {
            model = new CountryImplModel();
        }

        public int RecordCreation(CountryDTO dto)
        {
            CountryDTOMapper mapper = new CountryDTOMapper();
            CountryDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }
        public int RecordUpdate(CountryDTO dto)
        {
            CountryDTOMapper mapper = new CountryDTOMapper();
            CountryDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(CountryDTO dto)
        {
            CountryDTOMapper mapper = new CountryDTOMapper();
            CountryDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<CountryDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            CountryDTOMapper mapper = new CountryDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public CountryDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            CountryDTOMapper mapper = new CountryDTOMapper();
            return mapper.MapperT1T2(record);
        }
    }

}
