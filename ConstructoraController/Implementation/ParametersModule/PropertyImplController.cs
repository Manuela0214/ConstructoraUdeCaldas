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
    public class PropertyImpController
    {
        private PropertyImplModel model;

        public PropertyImpController()
        {
            model = new PropertyImplModel();
        }

        public int RecordCreation(PropertyDTO dto)
        {
            PropertyDTOMapper mapper = new PropertyDTOMapper();
            PropertyDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }
        public int RecordUpdate(PropertyDTO dto)
        {
            PropertyDTOMapper mapper = new PropertyDTOMapper();
            PropertyDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(PropertyDTO dto)
        {
            PropertyDTOMapper mapper = new PropertyDTOMapper();
            PropertyDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<PropertyDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            PropertyDTOMapper mapper = new PropertyDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public PropertyDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            PropertyDTOMapper mapper = new PropertyDTOMapper();
            return mapper.MapperT1T2(record);
        }
    }

}
