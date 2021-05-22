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
    public class BlockImpController
    {
        private BlockImplModel model;

        public BlockImpController()
        {
            model = new BlockImplModel();
        }

        public int RecordCreation(BlockDTO dto)
        {
            BlockDTOMapper mapper = new BlockDTOMapper();
            BlockDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordCreation(dbModel);
        }
        public int RecordUpdate(BlockDTO dto)
        {
            BlockDTOMapper mapper = new BlockDTOMapper();
            BlockDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(BlockDTO dto)
        {
            BlockDTOMapper mapper = new BlockDTOMapper();
            BlockDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<BlockDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            BlockDTOMapper mapper = new BlockDTOMapper();
            return mapper.MapperT1T2(list);
        }
        public BlockDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }

            BlockDTOMapper mapper = new BlockDTOMapper();
            return mapper.MapperT1T2(record);
        }
    }

}
