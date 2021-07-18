using ConstructoraController.DTO.ParametersModule;
using ConstructoraController.Implementation.ParametersModule;
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
        private CustomerImplController modelCustomer = new CustomerImplController();

        public override FinancialDTO MapperT1T2(FinancialDbModel input)
        {
            CustomerDTOMapper customerMapper = new CustomerDTOMapper();

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
                Customer = customerMapper.MapperT1T2(input.Customer)
            };
        }

        public override IEnumerable<FinancialDTO> MapperT1T2(IEnumerable<FinancialDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override FinancialDbModel MapperT2T1(FinancialDTO input)
        {
            return new FinancialDbModel
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

        public override IEnumerable<FinancialDbModel> MapperT2T1(IEnumerable<FinancialDTO> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}