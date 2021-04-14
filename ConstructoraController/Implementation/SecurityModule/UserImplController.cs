using ConstructoraController.DTO.SecurityModule;
using ConstructoraController.Mapper.SecurityModule;
using ConstructoraController.Services;
using ConstructoraModel.DbModel.SecurityModule;
using ConstructoraModel.Implementation.SecurityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraController.Implementation.SecurityModule
{
    public class UserImplController
    {
        private UserImplModel model;
        public UserImplController()
        {
            model = new UserImplModel();
        }
        public int RecordCreation(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            int response = model.RecordCreation(dbModel);
            //verifica si el usuario fue guardado para enviar un email
            if(response == 1)
            {
                new Notifications().SendEmail("User Registration", "Content...", dto.Email, "test@constructora.com");
            }
            return response;
        }

        public int RecordUpdate(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        public int RecordRemove(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        public IEnumerable<UserDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            UserDTOMapper mapper = new UserDTOMapper();
            return mapper.MapperT1T2(list);
        }

        public UserDTO Login(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            var obj = model.Login(dbModel);
            return mapper.MapperT1T2(obj);
        }

        public int PasswordReset(string currentPassword, string newPassword, int userId)
        {
            String email = string.Empty;
            var response =  model.PasswordReset(currentPassword,newPassword,userId,out email);
            if (response == 1)
            {
                new Notifications().SendEmail("Password Reset", "Content...", email, "test@constructora.com");
            }
            return response;
        }
    }
}
