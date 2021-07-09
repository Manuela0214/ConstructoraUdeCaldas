using ConstructoraController.DTO.ParametersModule;
using ConstructoraModel.DbModel.ParametersModule;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraController.Mapper.ParametersModule
{
    class RequestStatusDTOMapper : MapperBase<RequestStatusDbModel, RequestStatusDTO>
    {
        public override RequestStatusDTO MapperT1T2(RequestStatusDbModel input)
        {
            RequestStatusDTOMapper roleMapper = new RequestStatusDTOMapper();
            return new RequestStatusDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description
            };
        }

        public override IEnumerable<RequestStatusDTO> MapperT1T2(IEnumerable<RequestStatusDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override RequestStatusDbModel MapperT2T1(RequestStatusDTO input)
        {
            return new RequestStatusDbModel()
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description
            };
        }

        public override IEnumerable<RequestStatusDbModel> MapperT2T1(IEnumerable<RequestStatusDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}