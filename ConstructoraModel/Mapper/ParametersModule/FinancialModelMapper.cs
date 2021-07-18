using ConstructoraModel.DbModel.ParametersModule;
using ConstructoraModel.Implementation.ParametersModule;
using ConstructoraModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.Mapper.ParametersModule
{
    class FinancialModelMapper : MapperBase<PARAM_FINANCIAL, FinancialDbModel>
    {
        private CustomerImplModel model = new CustomerImplModel();

        public override FinancialDbModel MapperT1T2(PARAM_FINANCIAL input)
        {
            var customer = input.PARAM_CUSTOMER;
            CustomerModelMapper customerMapper = new CustomerModelMapper();

            //IEnumerable<CustomerDbModel> countries = model.RecordList("");

            return new FinancialDbModel
            {
                Id = input.ID,
                NameJob = input.NAMEJOB,
                PhoneJob = input.PHONEJOB,
                TotalInCome = input.TOTALINCOME,
                TimeCurrentJob = input.TIMECURRENTJOB,
                NameFamilyRef = input.NAMEFAMILYREF,
                CellphoneFamilyRef = input.CELLPHONEFAMILYREF,
                NamePersonalRef = input.NAMEPERSONALREF,
                CellphonePersonalRef = input.CELLPHONEPERSONALREF,
                Customer = customerMapper.MapperT1T2(customer)
            };
        }

        public override IEnumerable<FinancialDbModel> MapperT1T2(IEnumerable<PARAM_FINANCIAL> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override PARAM_FINANCIAL MapperT2T1(FinancialDbModel input)
        {
            return new PARAM_FINANCIAL
            {
                ID = input.Id,
                NAMEJOB = input.NameJob,
                PHONEJOB = input.PhoneJob,
                TOTALINCOME = input.TotalInCome,
                TIMECURRENTJOB = input.TimeCurrentJob,
                NAMEFAMILYREF = input.NameFamilyRef,
                CELLPHONEFAMILYREF = input.CellphoneFamilyRef,
                NAMEPERSONALREF = input.NamePersonalRef,
                CELLPHONEPERSONALREF = input.CellphonePersonalRef,
                CUSTOMERID = input.CustomerId
            };
        }

        public override IEnumerable<PARAM_FINANCIAL> MapperT2T1(IEnumerable<FinancialDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
