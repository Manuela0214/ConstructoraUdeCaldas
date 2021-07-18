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
        public override FinancialModel MapperT1T2(FinancialDTO input)
        {
            CustomerModelMapper customerMapper = new CustomerModelMapper();
            return new FinancialModel
            {
                Id = input.Id,
                NameJob = input.NameJob,
                PhoneJob = input.PhoneJob,
                TotalInCome = input.TotalInCome,
                TimeCurrentJob = input.TimeCurrentJob,
                NameFamilyRef = input.NameFamilyRef,
                CellphoneFamilyRef = input.CellphoneFamilyRef,
                NamePersonalRef = input.NamePersonalRef,
                CellphonePersonalRef = input.CellphonePersonalRef,
                Customer = customerMapper.MapperT1T2(input.Customer)
            };
        }

        public override IEnumerable<FinancialModel> MapperT1T2(IEnumerable<FinancialDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override FinancialDTO MapperT2T1(FinancialModel input)
        {
            return new FinancialDTO
            {
                Id = input.Id,
                NameJob = input.NameJob,
                PhoneJob = input.PhoneJob,
                TotalInCome = input.TotalInCome,
                TimeCurrentJob = input.TimeCurrentJob,
                NameFamilyRef = input.NameFamilyRef,
                CellphoneFamilyRef = input.CellphoneFamilyRef,
                NamePersonalRef = input.NamePersonalRef,
                CellphonePersonalRef = input.CellphonePersonalRef,
                CustomerId = input.CustomerId

            };
        }

        public override IEnumerable<FinancialDTO> MapperT2T1(IEnumerable<FinancialModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
