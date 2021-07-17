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
    public class CustomerImplController
    {
        private CustomerImplModel model;

        public CustomerImplController()
        {
            model = new CustomerImplModel();
        }

        public int RecordCreation(CustomerDTO dto)
        {
            CustomerDTOMapper mapper = new CustomerDTOMapper();
            CustomerDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }
        public int RecordUpdate(CustomerDTO dto)
        {
            CustomerDTOMapper mapper = new CustomerDTOMapper();
            CustomerDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(CustomerDTO dto)
        {
            CustomerDTOMapper mapper = new CustomerDTOMapper();
            CustomerDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<CustomerDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            CustomerDTOMapper mapper = new CustomerDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public CustomerDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            CustomerDTOMapper mapper = new CustomerDTOMapper();
            return mapper.MapperT1T2(record);
        }
    }

}
