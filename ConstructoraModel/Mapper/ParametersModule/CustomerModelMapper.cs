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
    class CustomerModelMapper : MapperBase<PARAM_CUSTOMER, CustomerDbModel>
    {
        private CityImplModel model = new CityImplModel();

        public override CustomerDbModel MapperT1T2(PARAM_CUSTOMER input)
        {
            var city = input.PARAM_CITY;
            CityModelMapper cityMapper = new CityModelMapper();

            //IEnumerable<CityDbModel> countries = model.RecordList("");

            return new CustomerDbModel
            {
                Id = input.ID,
                Document = input.DOCUMENT,
                Name = input.NAME,
                LastName = input.LASTNAME,
                DateBirth = input.DATEBIRTH,
                Picture = input.PICTURE,
                Cellphone = input.CELLPHONE,
                Email = input.EMAIL,
                Address = input.ADDRESS,
                City = cityMapper.MapperT1T2(city)
            };
        }

        public override IEnumerable<CustomerDbModel> MapperT1T2(IEnumerable<PARAM_CUSTOMER> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT1T2(intem);
            }
        }

        public override PARAM_CUSTOMER MapperT2T1(CustomerDbModel input)
        {
            return new PARAM_CUSTOMER
            {
                ID = input.Id,
                DOCUMENT = input.Document,
                NAME = input.Name,
                LASTNAME = input.LastName,
                DATEBIRTH = input.DateBirth,
                PICTURE = input.Picture,
                CELLPHONE = input.Cellphone,
                EMAIL = input.Email,
                ADDRESS = input.Address,
                CITYID = input.CityId
            };
        }

        public override IEnumerable<PARAM_CUSTOMER> MapperT2T1(IEnumerable<CustomerDbModel> input)
        {
            foreach (var intem in input)
            {
                yield return MapperT2T1(intem);
            }
        }
    }
}
