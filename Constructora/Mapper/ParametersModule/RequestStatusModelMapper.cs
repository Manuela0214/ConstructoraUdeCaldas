using Constructora.Models.ParametersModule;
using ConstructoraController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora.Mapper.ParametersModule
{
    class RequestStatusModelMapper : MapperBase<RequestStatusDTO, RequestStatusModel>
    {
        /// <summary>
        /// Method to map the RequestStatusDTO object to RequestStatusModel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override RequestStatusModel MapperT1T2(RequestStatusDTO input)
        {
            return new RequestStatusModel()
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description
            };
        }

        public override IEnumerable<RequestStatusModel> MapperT1T2(IEnumerable<RequestStatusDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override RequestStatusDTO MapperT2T1(RequestStatusModel input)
        {
            return new RequestStatusDTO()
            {
                Id = input.Id,
                Name = input.Name,
                Description = input.Description
            };
        }

        public override IEnumerable<RequestStatusDTO> MapperT2T1(IEnumerable<RequestStatusModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
