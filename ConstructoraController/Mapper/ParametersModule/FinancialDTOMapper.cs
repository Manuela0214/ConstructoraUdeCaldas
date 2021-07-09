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
    class FinancialDTOMapper : MapperBase<FinancialDbModel, FinancialDTO>
    {
        public override FinancialDTO MapperT1T2(FinancialDbModel input)
        {
            FinancialDTOMapper roleMapper = new FinancialDTOMapper();
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

        public override IEnumerable<FinancialDTO> MapperT1T2(IEnumerable<FinancialDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }

        public override FinancialDbModel MapperT2T1(FinancialDTO input)
        {
            return new FinancialDbModel()
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

        public override IEnumerable<FinancialDbModel> MapperT2T1(IEnumerable<FinancialDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}