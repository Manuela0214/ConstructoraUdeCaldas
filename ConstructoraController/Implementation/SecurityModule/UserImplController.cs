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
        private RoleImplModel roleModel;
        public UserImplController()
        {
            model = new UserImplModel();
            roleModel = new RoleImplModel();
        }

        /// <summary>
        /// Creación de un registro
        /// </summary>
        /// <param name="dto">Información dto</param>
        /// <returns>1: Ok, 2: Excepción, 3: Ya existe</returns>
        public int RecordCreation(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            Encrypt enc = new Encrypt();
            string randomPassword = enc.RandomString(10);
            string newPassword = enc.CreateMD5(randomPassword);
            dbModel.Password = newPassword;
            int response = model.RecordCreation(dbModel);            
            //verifica si el usuario fue guardado para enviar un email
            if(response == 1)
            {
                String content = String.Format("Buen día {0}, " +
                    "<br /> Usted ha sido registrado en la plataforma Contructora UdeC S.A.S. " +
                    "Sus credenciales de acceso son: <br/>" +
                    " <ul>" +
                    "<li> Usuario: {1}</li>" +
                    "<li>Contraseña: {2}</li>" +
                    "</ul>" +
                    "<br /> Cordial saludo, <br />" +
                    "Su equipo de seguridad.", dto.Name, dto.Email, randomPassword);
                new Notifications().SendEmail("Registro usuario UdeC", content, dto.Name, dto.Email);
            }
            return response;
        }

        /// <summary>
        /// Actualización de un registro
        /// </summary>
        /// <param name="dto">Información dto</param>
        /// <returns>1: Ok, 2: Excepción, 3: Ya existe</returns>
        public int RecordUpdate(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordUpdate(dbModel);
        }

        /// <summary>
        /// Eliminación de un registro
        /// </summary>
        /// <param name="dto">Información dto</param>
        /// <returns>1: Ok, 2: Excepción, 3: Ya existe</returns>
        public int RecordRemove(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            return model.RecordRemove(dbModel);
        }

        /// <summary>
        /// Se listan basandose en un filtro los registros de los usuarios
        /// </summary>
        /// <param name="filter">Representa filtro</param>
        /// <returns>Lista con los usuarios, teniendo su id y su nombre respectivo.</returns>
        public IEnumerable<UserDTO> RecordList(string filter)
        {
            var list = model.RecordList(filter);
            UserDTOMapper mapper = new UserDTOMapper();
            return mapper.MapperT1T2(list);
        }

        /// <summary>
        /// Iniciar sesión
        /// </summary>
        /// <param name="dto">Información dto</param>
        /// <returns>Modelo en la db</returns>
        public UserDTO Login(UserDTO dto)
        {
            UserDTOMapper mapper = new UserDTOMapper();
            UserDbModel dbModel = mapper.MapperT2T1(dto);
            dbModel.Password = new Encrypt().CreateMD5(dbModel.Password);
            var obj = model.Login(dbModel);
            return mapper.MapperT1T2(obj);
        }

        /// <summary>
        /// Restablecer la contraseña
        /// </summary>
        /// <param name="email">Representa el correo electrónico</param>
        /// <returns>1: Ok, 2:KO, 3.Ya existe</returns>
        public int PasswordReset(string email)
        {
            Encrypt enc = new Encrypt();
            string randomPassword = enc.RandomString(10);
            string newPassword = enc.CreateMD5(randomPassword);
            var response =  model.PasswordReset(email, newPassword);
            if (response == 1)
            {
                new Notifications().SendEmail("Password Reset", "Content...", email, "test@constructora.com");
            }
            return response;
        }
        /// <summary>
        /// Cambio de la contraseña
        /// </summary>
        /// <param name="email">Representa el correo electrónico</param>
        /// <returns>1: Ok, 2:KO, 3.Ya existe</returns>

        public int ChangePassword(string currentPassword, string newPassword, int userId)
        {
            String email = string.Empty;
            var response = model.ChangePassword(currentPassword, newPassword, userId, out email);
            if (response == 1)
            {
                new Notifications().SendEmail("Password Changed", "Content...", email, "test@constructora.com");
            }
            return response;
        }

        /// <summary>
        /// Busqueda de un usuario
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns>El registro</returns>
        public UserDTO RecordSearch(int id)
        {
            var record = model.RecordSearch(id);
            if (record == null)
            {
                return null;
            }
            UserDTOMapper mapper = new UserDTOMapper();
            return mapper.MapperT1T2(record);
        }

        /// <summary>
        /// Asignación de roles
        /// </summary>
        /// <param name="roleList">Répresenta la lista de id's de los roles</param>
        /// <param name="userId">Representa el id del usuario</param>
        /// <returns>True: Realiza asignación. False: No realiza asignación.</returns>
        public bool AssignRoles(List<int> roleList, int userId)
        {
            return model.AssignRoles(roleList, userId);
        }

        /// <summary>
        /// Se listan los roles que tiene un usuario
        /// </summary>
        /// <param name="userId">Representa el ud del usuario</param>
        /// <returns>Lista con los roles de un usuario, teniendo en cuenta su id.</returns>

        public IEnumerable<RoleDTO> RecordListByUser(int userId)
        {
            var list = roleModel.RecordListByUser(userId);
            RoleDTOMapper mapper = new RoleDTOMapper();
            return mapper.MapperT1T2(list);
        }
    }
}
