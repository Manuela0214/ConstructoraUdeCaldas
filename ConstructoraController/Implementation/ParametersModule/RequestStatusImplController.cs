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
    public class RequestStatusImplController
    {
        private RequestStatusImplModel model;

        public RequestStatusImplController()
        {
            model = new RequestStatusImplModel();
        }

        public int RecordCreation(RequestStatusDTO dto)
        {
            RequestStatusDTOMapper mapper = new RequestStatusDTOMapper();
            RequestStatusDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }
        public int RecordUpdate(RequestStatusDTO dto)
        {
            RequestStatusDTOMapper mapper = new RequestStatusDTOMapper();
            RequestStatusDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(RequestStatusDTO dto)
        {
            RequestStatusDTOMapper mapper = new RequestStatusDTOMapper();
            RequestStatusDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<RequestStatusDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            RequestStatusDTOMapper mapper = new RequestStatusDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public RequestStatusDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            RequestStatusDTOMapper mapper = new RequestStatusDTOMapper();
            return mapper.MapperT1T2(record);
        }
    }

}
