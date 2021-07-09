using Constructora.Models.ParametersModule;
using ConstructoraController.DTO.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora.Mapper.ParametersModule
{
    class FinancialModelMapper : MapperBase<FinancialDTO, FinancialModel>
    {
        /// <summary>
        /// Method to map the FinancialDTO object to FinancialModel
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override FinancialModel MapperT1T2(FinancialDTO input)
        {
            return new FinancialModel()
            {
                Id = input.Id,
                NameJob = input.NameJob,
                PhoneJob = input.PhoneJob,
                TotalInCome = input.TotalInCome,
                TimeCurrentJob = input.TimeCurrentJob,
                NameFamilyRef = input.NameFamilyRef,
                CellphoneFamilyRef = input.CellphoneFamilyRef,
                NamePersonalRef = input.NamePersonalRef,
                CellphonePersonalRef = input.CellphonePersonalRef
            };
        }

        public override IEnumerable<FinancialModel> MapperT1T2(IEnumerable<FinancialDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override FinancialDTO MapperT2T1(FinancialModel input)
        {
            return new FinancialDTO()
            {
                Id = input.Id,
                NameJob = input.NameJob,
                PhoneJob = input.PhoneJob,
                TotalInCome = input.TotalInCome,
                TimeCurrentJob = input.TimeCurrentJob,
                NameFamilyRef = input.NameFamilyRef,
                CellphoneFamilyRef = input.CellphoneFamilyRef,
                NamePersonalRef = input.NamePersonalRef,
                CellphonePersonalRef = input.CellphonePersonalRef
            };
        }

        public override IEnumerable<FinancialDTO> MapperT2T1(IEnumerable<FinancialModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
