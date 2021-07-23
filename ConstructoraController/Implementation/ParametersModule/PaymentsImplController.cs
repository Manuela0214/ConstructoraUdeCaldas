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
    public class PaymentsImplController
    {
        private PaymentsImplModel model;

        public PaymentsImplController()
        {
            model = new PaymentsImplModel();
        }

        public int RecordCreation(PaymentsDTO dto)
        {
            PaymentsDTOMapper mapper = new PaymentsDTOMapper();
            PaymentsDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }
        public int RecordUpdate(PaymentsDTO dto)
        {
            PaymentsDTOMapper mapper = new PaymentsDTOMapper();
            PaymentsDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(PaymentsDTO dto)
        {
            PaymentsDTOMapper mapper = new PaymentsDTOMapper();
            PaymentsDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<PaymentsDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            PaymentsDTOMapper mapper = new PaymentsDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public PaymentsDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            PaymentsDTOMapper mapper = new PaymentsDTOMapper();
            return mapper.MapperT1T2(record);
        }
    }

}
