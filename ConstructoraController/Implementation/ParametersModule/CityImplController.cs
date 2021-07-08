﻿using ConstructoraController.DTO.ParametersModule;
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
    public class CityImplController
    {
        private CityImplModel model;

        public CityImplController()
        {
            model = new CityImplModel();
        }

        public int RecordCreation(CityDTO dto)
        {
            CityDTOMapper mapper = new CityDTOMapper();
            CityDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }
        public int RecordUpdate(CityDTO dto)
        {
            CityDTOMapper mapper = new CityDTOMapper();
            CityDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(CityDTO dto)
        {
            CityDTOMapper mapper = new CityDTOMapper();
            CityDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<CityDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            CityDTOMapper mapper = new CityDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public CityDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            CityDTOMapper mapper = new CityDTOMapper();
            return mapper.MapperT1T2(record);
        }
    }

}
