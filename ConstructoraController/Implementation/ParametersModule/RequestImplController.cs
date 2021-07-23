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
    public class RequestImplController
    {
        private RequestImplModel model;

        public RequestImplController()
        {
            model = new RequestImplModel();
        }

        public int RecordCreation(RequestDTO dto)
        {
            RequestDTOMapper mapper = new RequestDTOMapper();
            RequestDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }
        public int RecordUpdate(RequestDTO dto)
        {
            RequestDTOMapper mapper = new RequestDTOMapper();
            RequestDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(RequestDTO dto)
        {
            RequestDTOMapper mapper = new RequestDTOMapper();
            RequestDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<RequestDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            RequestDTOMapper mapper = new RequestDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public RequestDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            RequestDTOMapper mapper = new RequestDTOMapper();
            return mapper.MapperT1T2(record);
        }
    }

}
