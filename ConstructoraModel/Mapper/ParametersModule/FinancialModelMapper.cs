using ConstructoraModel.DbModel.ParametersModule;
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
        public override FinancialDbModel MapperT1T2(PARAM_FINANCIAL input)
        {

            return new FinancialDbModel()
            {
                Id = input.ID,
                NameJob = input.NAMEJOB,
                PhoneJob = input.PHONEJOB,
                TotalInCome = input.TOTALINCOME,
                TimeCurrentJob = input.TIMECURRENTJOB,
                NameFamilyRef = input.NAMEFAMILYREF,
                CellphoneFamilyRef = input.CELLPHONEFAMILYREF,
                NamePersonalRef = input.NAMEPERSONALREF,
                CellphonePersonalRef = input.CELLPHONEPERSONALREF
            };
        }

        public override IEnumerable<FinancialDbModel> MapperT1T2(IEnumerable<PARAM_FINANCIAL> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1T2(item);
            }
        }
        
        /**internal object MapperT1T2(int FINANCIALID)
        {
            throw new NotImplementedException();
        }**/


        public override PARAM_FINANCIAL MapperT2T1(FinancialDbModel input)
        {
            return new PARAM_FINANCIAL()
            {
                ID = input.Id,
                NAMEJOB = input.NameJob,
                PHONEJOB = input.PhoneJob,
                TOTALINCOME = input.TotalInCome,
                TIMECURRENTJOB = input.TimeCurrentJob,
                NAMEFAMILYREF = input.NameFamilyRef,
                CELLPHONEFAMILYREF = input.CellphoneFamilyRef,
                NAMEPERSONALREF = input.NamePersonalRef,
                CELLPHONEPERSONALREF = input.CellphonePersonalRef

            };
        }

        public override IEnumerable<PARAM_FINANCIAL> MapperT2T1(IEnumerable<FinancialDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2T1(item);
            }
        }
    }
}
