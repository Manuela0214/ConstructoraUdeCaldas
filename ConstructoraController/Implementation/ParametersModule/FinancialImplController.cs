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
    public class FinancialImplController
    {
        private FinancialImplModel model;

        public FinancialImplController()
        {
            model = new FinancialImplModel();
        }

        public int RecordCreation(FinancialDTO dto)
        {
            FinancialDTOMapper mapper = new FinancialDTOMapper();
            FinancialDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }
        public int RecordUpdate(FinancialDTO dto)
        {
            FinancialDTOMapper mapper = new FinancialDTOMapper();
            FinancialDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(FinancialDTO dto)
        {
            FinancialDTOMapper mapper = new FinancialDTOMapper();
            FinancialDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<FinancialDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            FinancialDTOMapper mapper = new FinancialDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public FinancialDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            FinancialDTOMapper mapper = new FinancialDTOMapper();
            return mapper.MapperT1T2(record);
        }
    }

}
