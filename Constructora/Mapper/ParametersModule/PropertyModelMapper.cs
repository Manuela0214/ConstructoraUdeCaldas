using Constructora.Models.ParametersModule;
using ConstructoraController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora.Mapper.ParametersModule
{
    class PropertyModelMapper : MapperBase<PropertyDTO, PropertyModel>
    {
        /// <summary>
        /// Method to map the PropertyDTO object to PropertyModel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override PropertyModel MapperT1T2(PropertyDTO input)
        {
            return new PropertyModel()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Valor = input.Valor
            };
        }

        public override IEnumerable<PropertyModel> MapperT1T2(IEnumerable<PropertyDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override PropertyDTO MapperT2T1(PropertyModel input)
        {
            return new PropertyDTO()
            {
                Id = input.Id,
                Code = input.Code,
                Name = input.Name,
                Valor = input.Valor
            };
        }

        public override IEnumerable<PropertyDTO> MapperT2T1(IEnumerable<PropertyModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
